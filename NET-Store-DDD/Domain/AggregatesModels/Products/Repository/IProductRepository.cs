using StoreDDD.DomainCore.Repository;
using StoreDDD.DomainLayer.AggregatesModels.Products.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Products.Repository
{
    /// <summary>
    /// Interface ICustomerRepository
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        void UpdateWhithoutCode(Product product);
    }
}
