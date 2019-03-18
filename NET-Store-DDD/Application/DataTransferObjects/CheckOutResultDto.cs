using System;
using StoreDDD.DomainLayer.AggregatesModels.Carts.Models;

namespace StoreDDD.ApplicationLayer.DataTransferObjects
{
    /// <summary>
    /// Class CheckOutResultDto.
    /// </summary>
    public class CheckOutResultDto
    {
        /// <summary>
        /// Gets or sets the purchase identifier.
        /// </summary>
        /// <value>The purchase identifier.</value>
        public Guid? PurchaseId { get; set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>The total price.</value>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the check out issue.
        /// </summary>
        /// <value>The check out issue.</value>
        public CheckOutIssue CheckOutIssue { get; set; }
    }
}
