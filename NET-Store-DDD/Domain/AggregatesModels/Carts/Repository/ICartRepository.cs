using StoreDDD.DomainCore.Repository;
using StoreDDD.DomainLayer.AggregatesModels.Carts.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Carts.Repository
{
    /// <summary>
    /// Interface ICartRepository
    /// </summary>
    public interface ICartRepository : IRepository<Cart>
    {
    }
}
