using StoreDDD.DomainCore.Events;
using StoreDDD.DomainLayer.AggregatesModels.Purchases.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Events
{
    /// <summary>
    /// Class CustomerCheckOutEvent.
    /// </summary>
    public class CustomerCheckOutEvent : DomainEvent
    {
        /// <summary>
        /// Gets or sets the purchase.
        /// </summary>
        /// <value>The purchase.</value>
        public Purchase Purchase { get; set; }

        /// <summary>
        /// Flattens this instance.
        /// </summary>
        public override void Flatten()
        {
            Args.Add("CustomerId", Purchase.CustomerId);
            Args.Add("PurchaseId", Purchase.Id);
            Args.Add("TotalCost", Purchase.TotalPrice);
            Args.Add("NumberOfProducts", Purchase.Products.Count);
        }
    }
}
