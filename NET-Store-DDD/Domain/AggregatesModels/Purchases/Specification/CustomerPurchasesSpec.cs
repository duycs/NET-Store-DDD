using System;
using StoreDDD.DomainCore.Specification;
using StoreDDD.DomainLayer.AggregatesModels.Purchases.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Purchases.Specification
{
    /// <summary>
    /// Class PurchasedNProductsSpec.
    /// </summary>
    public class CustomerPurchasesSpec : SpecificationBase<Purchase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerPurchasesSpec"/> class.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerPurchasesSpec(Guid customerId)
            : base(purchase => purchase.CustomerId == customerId)
        {
        }
    }
}
