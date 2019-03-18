using System;
using System.ComponentModel.DataAnnotations;

namespace StoreDDD.ApplicationLayer.Models
{
    /// <summary>
    /// Class UpdateCustomerViewModel.
    /// </summary>
    public class UpdateCustomerViewModel 
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Required(ErrorMessage = "Customer id is required")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Required(ErrorMessage = "The first name is required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Required(ErrorMessage = "The last name is required")]
        public string LastName { get; set; }

    }
}
