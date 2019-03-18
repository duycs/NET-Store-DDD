using System;
using System.Collections.Generic;

namespace StoreDDD.ApplicationLayer.DataTransferObjects
{
    /// <summary>
    /// Class CartDto.
    /// </summary>
    public class CartDto
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public List<CartProductDto> Products { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }
    }
}
