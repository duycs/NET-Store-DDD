using StoreDDD.DomainLayer.AggregatesModels.Purchases.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreDDD.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// Class PurchasedProductEntityTypeConfiguration.
    /// </summary>
    public class PurchasedProductEntityTypeConfiguration : IEntityTypeConfiguration<PurchasedProduct>
    {
        /// <summary>
        /// Configures the specified purchase configuration.
        /// </summary>
        /// <param name="purchaseConfiguration">The purchase configuration.</param>
        public void Configure(EntityTypeBuilder<PurchasedProduct> purchaseConfiguration)
        {
            purchaseConfiguration.ToTable("PurchasedProduct");
            purchaseConfiguration.HasKey(b => b.Id);
        }
    }
}
