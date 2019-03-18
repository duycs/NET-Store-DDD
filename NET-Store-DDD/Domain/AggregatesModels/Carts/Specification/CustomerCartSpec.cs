using System;
using StoreDDD.DomainCore.Specification;
using StoreDDD.DomainLayer.AggregatesModels.Carts.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Carts.Specification
{
    /// <summary>
    /// Class CustomerCartSpec.
    /// </summary>
    public class CustomerCartSpec : SpecificationBase<Cart>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCartSpec"/> class.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerCartSpec(Guid customerId) : base(cart => cart.CustomerId == customerId)
        {
        }
    }
}
