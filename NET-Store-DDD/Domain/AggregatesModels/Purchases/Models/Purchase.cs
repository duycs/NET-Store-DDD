using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using StoreDDD.DomainCore.Models;
using StoreDDD.DomainLayer.AggregatesModels.Carts.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Purchases.Models
{
    /// <summary>
    /// Class Purchase.
    /// </summary>
    public class Purchase : Entity, IAggregateRoot
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        public ICollection<PurchasedProduct> Products { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public Guid CustomerId { get; protected set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>The total price.</value>
        public decimal TotalPrice { get; protected set; }

        /// <summary>
        /// Creates the specified cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>Purchase.</returns>
        public static Purchase Create(Cart cart)
        {
            var purchase = new Purchase
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Today,
                CustomerId = cart.CustomerId,
                TotalPrice = cart.TotalPrice,
            };

            var purchasedProducts = cart.Products.Select(cartProduct => PurchasedProduct.Create(purchase, cartProduct)).ToList();
            purchase.Products = purchasedProducts;

            return purchase;
        }
    }
}
