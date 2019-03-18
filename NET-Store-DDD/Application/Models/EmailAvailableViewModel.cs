using System.ComponentModel.DataAnnotations;

namespace StoreDDD.ApplicationLayer.Models
{
    /// <summary>
    /// Class EmailAvailableViewModel.
    /// </summary>
    public class EmailAvailableViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
