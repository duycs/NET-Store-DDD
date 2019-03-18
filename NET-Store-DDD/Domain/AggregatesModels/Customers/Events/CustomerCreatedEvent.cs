using StoreDDD.DomainCore.Events;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Events
{
    /// <summary>
    /// Class CustomerCreatedEvents.
    /// </summary>
    public class CustomerCreatedEvent : DomainEvent
    {
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }

        /// <summary>
        /// Flattens this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Flatten()
        {
            Args.Add("FirstName", Customer.FirstName);
            Args.Add("LastName", Customer.LastName);
            Args.Add("Email", Customer.Email);
            Args.Add("Password", Customer.Password);
        }
    }
}
