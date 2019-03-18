using System;
using System.Linq;
using AutoMapper;
using StoreDDD.ApplicationLayer.DataTransferObjects;
using StoreDDD.ApplicationLayer.Models;
using StoreDDD.DomainCore.Commands;
using StoreDDD.DomainCore.Repository;
using StoreDDD.DomainCore.Specification;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Commands;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Models;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Repository;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Specification;
using StoreDDD.DomainLayer.AggregatesModels.Purchases.Models;
using StoreDDD.DomainLayer.AggregatesModels.Purchases.Specification;
using StoreDDD.Infrastructure.Components.Cryptography;

namespace StoreDDD.ApplicationLayer.Services
{
    /// <summary>
    /// Class CustomerService.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IRepository<Purchase> _purchaseRepository;
        private readonly IRepository<PurchasedProduct> _purchaseProductRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="customerRepository">The customer repository.</param>
        /// <param name="commandDispatcher">The command dispatcher.</param>
        /// <param name="purchaseProductRepository">The purchase product repository.</param>
        /// <param name="purchaseRepository">The purchase repository.</param>
        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, ICommandDispatcher commandDispatcher,
            IRepository<PurchasedProduct> purchaseProductRepository, IRepository<Purchase> purchaseRepository)
        {
            _mapper = mapper;
            _purchaseRepository = purchaseRepository;
            _customerRepository = customerRepository;
            _commandDispatcher = commandDispatcher;
            _purchaseProductRepository = purchaseProductRepository;
        }

        /// <summary>
        /// Determines whether [is email available] [the specified email].
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns><c>true</c> if [is email available] [the specified email]; otherwise, <c>false</c>.</returns>
        public bool IsEmailAvailable(string email)
        {
            ISpecification<Customer> alreadyRegisteredSpec = new CustomerAlreadyRegisteredSpec(email);

            var existingCustomer = _customerRepository.FindSingleBySpec(alreadyRegisteredSpec);
            return existingCustomer == null;
        }

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CustomerDto.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public CustomerDto GetCustomerById(Guid customerId)
        {
            var customer = _customerRepository.FindById(customerId);
            return _mapper.Map<CustomerDto>(customer);
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Add(AddNewCustomerViewModel model)
        {
            var createCustomerCommand = _mapper.Map<CreateCustomerCommand>(model);

            // TODO Get password by MD5 enscript

            _commandDispatcher.Send(createCustomerCommand);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(UpdateCustomerViewModel model)
        {
            var updateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(model);
            _commandDispatcher.Send(updateCustomerCommand);
        }

        /// <summary>
        /// Removes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Remove(RemoveCustomerViewModel model)
        {
            var removeCustomerCommand = _mapper.Map<RemoveCustomerCommand>(model);
            _commandDispatcher.Send(removeCustomerCommand);
        }

        /// <summary>
        /// Gets the customer purchase history.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CustomerPurchaseHistoryDto.</returns>
        public CustomerPurchaseHistoryDto GetCustomerPurchaseHistory(Guid customerId)
        {
            var customer = _customerRepository.FindById(customerId);
            if (customer == null) return null;

            var customerPurchases = _purchaseRepository.Find(new CustomerPurchasesSpec(customer.Id)).ToList();
            foreach (var customerPurchase in customerPurchases)
            {
                customerPurchase.Products = _purchaseProductRepository.Find(new PurchasedProductsSpec(customerPurchase.Id)).ToList();
            }
            var customerPurchaseHistory = new CustomerPurchaseHistoryDto
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                TotalPurchases = customerPurchases.Count,
                TotalProductsPurchased = customerPurchases.Sum(purchase => purchase.Products.Sum(product => product.Quantity)),
                TotalPrice = customerPurchases.Sum(purchase => purchase.TotalPrice)
            };
            return customerPurchaseHistory;
        }

        /// <summary>
        /// remove customer by id
        /// </summary>
        /// <param name="customerId"></param>
        public void Remove(Guid customerId)
        {
            var customer = _customerRepository.FindById(customerId);
            var removeCustomerCommand = _mapper.Map<RemoveCustomerCommand>(customer);
            _commandDispatcher.Send(removeCustomerCommand);
        }

        /// <summary>
        /// Get customer by email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public CustomerDto GetCustomerByEmailAndPassword(string email, string password)
        {
            ISpecification<Customer> alreadyRegisteredSpec = new CustomerAlreadyRegisteredSpec(email);
            var customer = _customerRepository.FindSingleBySpec(alreadyRegisteredSpec);
            return _mapper.Map<CustomerDto>(customer); throw new NotImplementedException();
        }
    }
}
