using StoreDDD.DomainCore.Specification;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Specification
{
    /// <summary>
    /// Class CustomerAlreadyRegisteredSpec.
    /// </summary>
    public sealed class CustomerAlreadyRegisteredSpec : SpecificationBase<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAlreadyRegisteredSpec"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        public CustomerAlreadyRegisteredSpec(string email)
            : base(b => b.Email == email)
        {
        }
    }
}
