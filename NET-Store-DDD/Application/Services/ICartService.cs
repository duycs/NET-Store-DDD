using System;
using StoreDDD.ApplicationLayer.DataTransferObjects;
using StoreDDD.ApplicationLayer.Models;

namespace StoreDDD.ApplicationLayer.Services
{
    /// <summary>
    /// Interface ICartService
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Gets the by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CartDto.</returns>
        CartDto GetProductsInCartByCustomerId(Guid customerId);

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Add(AddProudctToCartViewModel model);

        /// <summary>
        /// Removes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Remove(RemoveProductFromCartViewModel model);

        /// <summary>
        /// Checks the out.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CheckOutResultDto.</returns>
        CheckOutResultDto CheckOut(Guid customerId);
    }
}
