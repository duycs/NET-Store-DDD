using System;
using System.ComponentModel.DataAnnotations.Schema;
using StoreDDD.DomainCore.Models;
using StoreDDD.DomainLayer.AggregatesModels.Carts.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Purchases.Models
{
    /// <summary>
    /// Class PurchasedProduct.
    /// </summary>
    public class PurchasedProduct : Entity
    {
        /// <summary>
        /// Gets or sets the purchase identifier.
        /// </summary>
        /// <value>The purchase identifier.</value>
        public Guid PurchaseId { get; protected set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public Guid ProductId { get; protected set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get; protected set; }

        /// <summary>
        /// Creates the specified purchase.
        /// </summary>
        /// <param name="purchase">The purchase.</param>
        /// <param name="cartProduct">The cart product.</param>
        /// <returns>PurchasedProduct.</returns>
        public static PurchasedProduct Create(Purchase purchase, CartProduct cartProduct)
        {
            return new PurchasedProduct
            {
                Id = Guid.NewGuid(),
                ProductId = cartProduct.ProductId,
                PurchaseId = purchase.Id,
                Quantity = cartProduct.Quantity
            };
        }
    }
}
