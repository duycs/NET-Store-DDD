using System;
using System.Linq;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Models;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Repository;
using StoreDDD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace StoreDDD.Infrastructure.Repositories
{
    /// <summary>
    /// Class CustomerRepository.
    /// </summary>
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CustomerRepository(StoreContext dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// Finds the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Customer.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Customer FindByEmail(string email)
        {
            return StoreContext.Customers.AsNoTracking().FirstOrDefault(c => c.Email.Equals(email));
        }

        /// <summary>
        /// Finds the one.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Customer.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Customer FindOne(Guid id)
        {
            return StoreContext.Customers.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Updates the without email and password.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateWithoutEmailAndPassword(Customer customer)
        {
            var customerEntry = StoreContext.Entry(customer);
            customerEntry.Property("FirstName").IsModified = true;
            customerEntry.Property("LastName").IsModified = true;
            customerEntry.Property("Email").IsModified = true;
        }
    }
}
