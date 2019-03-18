using System;
using System.Collections.Generic;
using AutoMapper;
using StoreDDD.ApplicationLayer.DataTransferObjects;
using StoreDDD.ApplicationLayer.Models;
using StoreDDD.DomainCore.Commands;
using StoreDDD.DomainLayer.AggregatesModels.Products.Commands;
using StoreDDD.DomainLayer.AggregatesModels.Products.Repository;

namespace StoreDDD.ApplicationLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDispatcher _commandDispatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="commandDispatcher">The command dispatcher.</param>
        public ProductService(IMapper mapper, IProductRepository productRepository, ICommandDispatcher commandDispatcher)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _commandDispatcher = commandDispatcher;
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>ProductDto.</returns>
        public ProductDto GetProductById(Guid productId)
        {
            var product = _productRepository.FindById(productId);
            return _mapper.Map<ProductDto>(product);
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Add(AddNewProductViewModel model)
        {
            var createProductCommand = _mapper.Map<CreateProductCommand>(model);
            _commandDispatcher.Send(createProductCommand);
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductDto> GetAll()
        {
            var product = _productRepository.Find();
            return _mapper.Map<List<ProductDto>>(product);
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            var product = _productRepository.FindById(id);
            var removeProductCommand = _mapper.Map<RemoveProductCommand>(product);
            _commandDispatcher.Send(removeProductCommand);
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="model"></param>
        public void Update(UpdateProductViewModel model)
        {
            var updateProductCommand = _mapper.Map<UpdateProductCommand>(model);
            _commandDispatcher.Send(updateProductCommand);
        }
    }
}
