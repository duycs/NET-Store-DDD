using System;
using StoreDDD.DomainCore.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Countries
{
    /// <summary>
    /// Class Country.
    /// </summary>
    public class Country : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; protected set; }

        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Country.</returns>
        public static Country Create(string name)
        {
            return Create(Guid.NewGuid(), name);
        }

        /// <summary>
        /// Creates the specified country identifier.
        /// </summary>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns>Country.</returns>
        public static Country Create(Guid countryId, string name)
        {
            var country = new Country()
            {
                Id = countryId,
                Name = name
            };
            return country;
        }
    }
}
