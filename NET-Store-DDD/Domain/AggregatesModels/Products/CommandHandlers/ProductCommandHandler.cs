using System.Threading;
using System.Threading.Tasks;
using StoreDDD.DomainCore.Events;
using StoreDDD.DomainCore.Notification;
using StoreDDD.DomainCore.UnitOfWork;
using StoreDDD.DomainLayer.AggregatesModels.Products.Repository;
using StoreDDD.DomainLayer.AggregatesModels.Products.Commands;
using StoreDDD.DomainLayer.AggregatesModels.Products.Events;
using StoreDDD.DomainLayer.AggregatesModels.Products.Models;
using StoreDDD.DomainLayer.AggregatesModels.Products.Specification;
using MediatR;

namespace StoreDDD.DomainLayer.AggregatesModels.Products.CommandHandlers
{
    /// <summary>
    /// Class ProductCommandHandler.
    /// </summary>
    public class ProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCommandHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="eventDispatcher">The event dispatcher.</param>
        public ProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IEventDispatcher eventDispatcher)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _eventDispatcher = eventDispatcher;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                    await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
                return Unit.Value;
            }

            var product = Product.Create(request.Name, request.Code, request.Quantity, request.Cost);

            var productAlreadyCreatedSpec = new ProductAlreadyCreatedSpec(product.Code);
            var existingProduct = _productRepository.FindSingleBySpec(productAlreadyCreatedSpec);
            if (existingProduct != null)
            {
                await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"The product code has already been taken"));
                return Unit.Value;
            }

            //add product
            var productAdded = _productRepository.Add(product);
            if (productAdded == null)
            {
                await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"new product could not insert"));
                return Unit.Value;
            }
            _unitOfWork.Commit();

            //raise events send email & store event
            await _eventDispatcher.RaiseEvent(new ProductCreatedEvent { Product = productAdded });

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                    await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
                return Unit.Value;
            }

            var product = new Product();
            if (string.IsNullOrEmpty(request.Code))
            {
                product = Product.UpdateWhithoutCode(request.Id, request.Name, request.Quantity, request.Cost);
                _productRepository.UpdateWhithoutCode(product);
            }
            else
            {
                product = Product.Update(request.Id, request.Code, request.Name, request.Quantity, request.Cost);
                _productRepository.Update(product);
            }

            _unitOfWork.Commit();

            //raise events send email & store event
            await _eventDispatcher.RaiseEvent(new ProductCreatedEvent { Product = product });

            return Unit.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                    await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
                return Unit.Value;
            }

            var product = _productRepository.FindById(request.Id);
            if (product == null)
            {
                await _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"The product does not exit in system"));
                return Unit.Value;
            }

            _productRepository.Delete(product);
            _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}
