using StoreDDD.DomainLayer.AggregatesModels.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreDDD.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// Class CountryEntityTypeConfiguration.
    /// </summary>
    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        /// <summary>
        /// Configures the specified customer configuration.
        /// </summary>
        /// <param name="countryConfiguration">The country configuration.</param>
        public void Configure(EntityTypeBuilder<Country> countryConfiguration )
        {
            countryConfiguration.ToTable("Country");
            countryConfiguration.HasKey(b => b.Id);
        }
    }
}
