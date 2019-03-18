using System;
using System.ComponentModel.DataAnnotations;

namespace StoreDDD.ApplicationLayer.Models
{
    /// <summary>
    /// Class RemoveProductFromCartViewModel.
    /// </summary>
    public class RemoveProductFromCartViewModel
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Required(ErrorMessage = "Customer id is required")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        [Required(ErrorMessage = "Product id is required")]
        public Guid ProductId { get; set; }
    }
}
