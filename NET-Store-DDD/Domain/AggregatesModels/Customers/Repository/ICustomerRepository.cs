using System;
using StoreDDD.DomainCore.Repository;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Repository
{
    /// <summary>
    /// Interface ICustomerRepository
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Finds the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Customer.</returns>
        Customer FindByEmail(string email);

        /// <summary>
        /// Finds the one.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Customer.</returns>
        Customer FindOne(Guid id);

        /// <summary>
        /// Updates the without email and password.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void UpdateWithoutEmailAndPassword(Customer customer);
    }
}
