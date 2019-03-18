using StoreDDD.DomainLayer.AggregatesModels.Purchases.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreDDD.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// Class PurchaseEntityTypeConfiguration.
    /// </summary>
    public class PurchaseEntityTypeConfiguration : IEntityTypeConfiguration<Purchase>
    {
        /// <summary>
        /// Configures the specified purchase configuration.
        /// </summary>
        /// <param name="purchaseConfiguration">The purchase configuration.</param>
        public void Configure(EntityTypeBuilder<Purchase> purchaseConfiguration)
        {
            purchaseConfiguration.ToTable("Purchase");
            purchaseConfiguration.HasKey(b => b.Id);
            purchaseConfiguration.Property(b => b.TotalPrice).HasColumnType("money");
            purchaseConfiguration.HasMany(c => c.Products);
        }
    }
}
