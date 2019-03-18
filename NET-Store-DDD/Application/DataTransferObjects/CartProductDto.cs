using System;

namespace StoreDDD.ApplicationLayer.DataTransferObjects
{
    /// <summary>
    /// Class CartProductDto.
    /// </summary>
    public class CartProductDto
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get; set; }
    }
}
