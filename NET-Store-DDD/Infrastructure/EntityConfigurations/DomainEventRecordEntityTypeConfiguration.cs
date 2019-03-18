using StoreDDD.DomainCore.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreDDD.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// Class CountryEntityTypeConfiguration.
    /// </summary>
    public class DomainEventRecordEntityTypeConfiguration : IEntityTypeConfiguration<DomainEventRecord>
    {
        /// <summary>
        /// Configures the specified country configuration.
        /// </summary>
        /// <param name="countryConfiguration">The country configuration.</param>
        public void Configure(EntityTypeBuilder<DomainEventRecord> countryConfiguration )
        {
            countryConfiguration.ToTable("DomainEventRecord");
            countryConfiguration.HasKey(b => b.CorrelationId);
        }
    }
}
