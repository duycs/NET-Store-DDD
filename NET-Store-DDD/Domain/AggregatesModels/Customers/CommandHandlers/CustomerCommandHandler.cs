using System.Threading;
using System.Threading.Tasks;
using StoreDDD.DomainCore.Events;
using StoreDDD.DomainCore.Notification;
using StoreDDD.DomainCore.Repository;
using StoreDDD.DomainCore.UnitOfWork;
using StoreDDD.DomainLayer.AggregatesModels.Countries;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Commands;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Events;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Models;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Repository;
using MediatR;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.CommandHandlers
{
    /// <summary>
    /// Class CustomerCommandHandler.
    /// </summary>
    public class CustomerCommandHandler : IRequestHandler<CreateCustomerCommand>, IRequestHandler<UpdateCustomerCommand>, IRequestHandler<RemoveCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCommandHandler" /> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository.</param>
        /// <param name="countryRepository">The country repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="eventDispatcher">The event dispatcher.</param>
        public CustomerCommandHandler(ICustomerRepository customerRepository, IRepository<Country> countryRepository, IUnitOfWork unitOfWork,
            IEventDispatcher eventDispatcher)
        {
            _customerRepository = customerRepository;
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
            _eventDispatcher = eventDispatcher;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                    await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
                return Unit.Value;
            }

            var country = _countryRepository.FindById(request.CountryId);
            if (country == null)
            {
                await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"Country id does not exit in system"));
                return Unit.Value;
            }

            var customer = Customer.Create(request.FirstName, request.LastName, request.Email, request.SecurityStamp, request.PasswordHash, country);

            var existingCustomer = _customerRepository.FindByEmail(customer.Email);
            if (existingCustomer != null)
            {
                await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"The customer e-mail has already been taken"));
                return Unit.Value;
            }

            //add customer
            var customerAdded = _customerRepository.Add(customer);
            if (customerAdded == null)
            {
                await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"new customer could not insert"));
                return Unit.Value;
            }
            _unitOfWork.Commit();

            //raise events send email & store event
            await _eventDispatcher.RaiseEvent(new CustomerCreatedEvent { Customer = customerAdded });

            return Unit.Value;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                    await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
                return Unit.Value;
            }

            var country = _countryRepository.FindById(request.CountryId);
            if (country == null)
            {
                await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"Country id does not exit in system"));
                return Unit.Value;
            }

            var existingCustomer = _customerRepository.FindOne(request.Id);
            if (existingCustomer == null)
            {
                await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"The customer does not exit in system"));
                return Unit.Value;
            }

            var customer = new Customer();
            if (string.IsNullOrEmpty(request.Email) && string.IsNullOrEmpty(request.PasswordHash))
            {
                customer = Customer.UpdateWithoutEmailAndPassword(request.Id, request.FirstName, request.LastName, country);
                _customerRepository.UpdateWithoutEmailAndPassword(customer);
            }
            else
            {
                customer = Customer.Update(request.Id, request.FirstName, request.LastName, request.Email, country, request.PasswordHash);
                _customerRepository.Update(customer);
            }

            _unitOfWork.Commit();

            await _eventDispatcher.RaiseEvent(new CustomerUpdatedEvent { Customer = customer });

            return Unit.Value;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public async Task<Unit> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                    await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
                return Unit.Value;
            }

            var existingCustomer = _customerRepository.FindOne(request.Id);
            if (existingCustomer == null)
            {
                await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"The customer does not exit in system"));
                return Unit.Value;
            }

            //remove customer
            _customerRepository.Delete(existingCustomer);
            _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}
