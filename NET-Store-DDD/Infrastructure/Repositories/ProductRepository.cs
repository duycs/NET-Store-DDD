using StoreDDD.DomainLayer.AggregatesModels.Products.Models;
using StoreDDD.DomainLayer.AggregatesModels.Products.Repository;
using StoreDDD.Infrastructure.Context;

namespace StoreDDD.Infrastructure.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ProductRepository(StoreContext dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// Update without code
        /// </summary>
        /// <param name="product"></param>
        public void UpdateWhithoutCode(Product product)
        {
            var entityEntry = StoreContext.Entry(product);
            entityEntry.Property("Name").IsModified = true;
            entityEntry.Property("Quantity").IsModified = true;
            entityEntry.Property("Cost").IsModified = true;
        }
    }
}
