using System;
using StoreDDD.ApplicationLayer.DataTransferObjects;
using StoreDDD.ApplicationLayer.Models;
using System.Collections.Generic;

namespace StoreDDD.ApplicationLayer.Services
{
    /// <summary>
    /// Interface IProductService
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>ProductDto.</returns>
        ProductDto GetProductById(Guid id);

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductDto> GetAll();

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Add(AddNewProductViewModel model);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        void Update(UpdateProductViewModel model);



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);
    }
}
