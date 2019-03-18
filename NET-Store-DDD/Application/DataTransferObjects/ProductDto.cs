using System;

namespace StoreDDD.ApplicationLayer.DataTransferObjects
{
    /// <summary>
    /// Class ProductDto.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public virtual DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>The modified date.</value>
        public virtual DateTime ModifiedDate { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public virtual bool IsActive { get; protected set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public virtual int Quantity { get; protected set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        public virtual decimal Cost { get; protected set; }
    }
}
