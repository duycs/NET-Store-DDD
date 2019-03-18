using StoreDDD.DomainCore.Specification;
using StoreDDD.DomainLayer.AggregatesModels.Purchases.Models;
using System;

namespace StoreDDD.DomainLayer.AggregatesModels.Purchases.Specification
{
    /// <summary>
    /// Class PurchasedProductsSpec.
    /// </summary>
    public class PurchasedProductsSpec : SpecificationBase<PurchasedProduct>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchasedProductsSpec"/> class.
        /// </summary>
        /// <param name="purchaseId">The purchase identifier.</param>
        public PurchasedProductsSpec(Guid purchaseId)
          : base(purchasedProduct => purchasedProduct.PurchaseId == purchaseId)
        {
        }
    }
}
