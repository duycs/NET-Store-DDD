using StoreDDD.DomainCore.Events;
using StoreDDD.DomainLayer.AggregatesModels.Products.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Products.Events
{
    /// <summary>
    /// Class ProductCreatedEvent.
    /// </summary>
    public class ProductCreatedEvent : DomainEvent
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public Product Product { get; set; }

        /// <summary>
        /// Flattens this instance.
        /// </summary>
        public override void Flatten()
        {
            Args.Add("Name", Product.Name);
            Args.Add("Code", Product.Code);
            Args.Add("Quantity", Product.Quantity);
            Args.Add("Cost", Product.Cost);
            Args.Add("IsActive", Product.IsActive);
            Args.Add("ModifiedDate", Product.ModifiedDate);
            Args.Add("CreatedDate", Product.CreatedDate);
        }
    }
}
