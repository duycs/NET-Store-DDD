using StoreDDD.DomainCore.Events;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Events
{
    public class CustomerUpdatedEvent : DomainEvent
    {
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }

        /// <summary>
        /// Flattens this instance.
        /// </summary>
        public override void Flatten()
        {
            Args.Add("FirstName", Customer.FirstName);
            Args.Add("LastName", Customer.LastName);
            Args.Add("Country", Customer.CountryId);
        }
    }
}
