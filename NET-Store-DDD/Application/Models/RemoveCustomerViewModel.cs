using System;
using System.ComponentModel.DataAnnotations;

namespace StoreDDD.ApplicationLayer.Models
{
    /// <summary>
    /// Class RemoveCustomerViewModel.
    /// </summary>
    public class RemoveCustomerViewModel
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Required(ErrorMessage = "Customer id is required")]
        public Guid CustomerId { get; set; }
    }
}
