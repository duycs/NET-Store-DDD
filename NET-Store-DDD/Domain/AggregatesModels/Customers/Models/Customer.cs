using System;
using StoreDDD.DomainCore.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Models
{
    /// <summary>
    /// Class Customer.
    /// </summary>
    public class Customer : Entity, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public virtual string FirstName { get; protected set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public virtual string LastName { get; protected set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public virtual string Email { get; protected set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public virtual string Password { get; protected set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        public virtual  decimal Balance { get; protected set; }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Customer Create(string firstName, string lastName, string email, string password)
        {
            return Create(Guid.NewGuid(), firstName, lastName, email, password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Customer Create(Guid id, string firstName, string lastName, string email, string password)
        {
            var customer = new Customer
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
            };

            return customer;
        }

        /// <summary>
        /// Updates the without email and password.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="country">The country.</param>
        /// <returns>Customer.</returns>
        public static Customer UpdateWithoutEmailAndPassword(Guid id, string firstName, string lastName)
        {
            var customer = new Customer
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
            };

            return customer;
        }

        public static Customer Update(Guid id, string firstName, string lastName, string email, string password)
        {
            var customer = new Customer
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
            };

            return customer;
        }
    }
}
