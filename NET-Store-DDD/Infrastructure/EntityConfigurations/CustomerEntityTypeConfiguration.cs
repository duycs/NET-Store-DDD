using StoreDDD.DomainLayer.AggregatesModels.Customers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreDDD.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// Class CustomerEntityTypeConfiguration.
    /// </summary>
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Configures the specified customer configuration.
        /// </summary>
        /// <param name="customerConfiguration">The customer configuration.</param>
        public void Configure(EntityTypeBuilder<Customer> customerConfiguration )
        {
            customerConfiguration.ToTable("Customer");
            customerConfiguration.HasKey(c => c.Id);
            customerConfiguration.Property(b => b.Balance).HasColumnType("money");
        }
    }
}
