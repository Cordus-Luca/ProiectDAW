using ProiectRestanta.Entities;
using ProiectRestanta.Repositories;

namespace ProiectRestanta.Repositories.ShopRepository
{
    public interface IShopRepository : IGenericRepository<Shop>
    {
        Task<Shop> GetByName(string name);
        Task<List<Shop>> GetAllShopsWithStock();

    }
}
