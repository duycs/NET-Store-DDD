using System;
using StoreDDD.DomainCore.Specification;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Specification
{
    public class CustomerRegisteredSpec : SpecificationBase<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRegisteredSpec"/> class.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerRegisteredSpec(Guid customerId) : base(b => b.Id == customerId)
        {
        }
    }
}
