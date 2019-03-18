using StoreDDD.DomainLayer.AggregatesModels.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreDDD.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// Class ProductEntityTypeConfiguration.
    /// </summary>
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Configures the specified product configuration.
        /// </summary>
        /// <param name="productConfiguration">The product configuration.</param>
        public void Configure(EntityTypeBuilder<Product> productConfiguration)
        {
            productConfiguration.ToTable("Product");
            productConfiguration.HasKey(b => b.Id);
            productConfiguration.Property(b => b.Cost).HasColumnType("money");
        }
    }
}
