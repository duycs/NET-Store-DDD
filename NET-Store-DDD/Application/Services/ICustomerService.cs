using System;
using StoreDDD.ApplicationLayer.DataTransferObjects;
using StoreDDD.ApplicationLayer.Models;

namespace StoreDDD.ApplicationLayer.Services
{
    /// <summary>
    /// Interface ICustomerAppService
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Determines whether [is email available] [the specified email].
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns><c>true</c> if [is email available] [the specified email]; otherwise, <c>false</c>.</returns>
        bool IsEmailAvailable(string email);

        /// <summary>
        /// Get customer by email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        CustomerDto GetCustomerByEmailAndPassword(string email, string password);

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CustomerDto.</returns>
        CustomerDto GetCustomerById(Guid customerId);

        /// <summary>
        /// Gets the customer purchase history.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CustomerPurchaseHistoryDto.</returns>
        CustomerPurchaseHistoryDto GetCustomerPurchaseHistory(Guid customerId);

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Add(AddNewCustomerViewModel model);

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(UpdateCustomerViewModel model);

        /// <summary>
        /// Removes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Remove(Guid customerId);
    }
}
