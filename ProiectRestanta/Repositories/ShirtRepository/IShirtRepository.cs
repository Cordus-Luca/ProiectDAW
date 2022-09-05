using ProiectRestanta.Entities;

namespace ProiectRestanta.Repositories.ShirtRepository
{
    public interface IShirtRepository : IGenericRepository<Shirt>
    {
        Task<Shirt> GetByColor(string color);
        Task<List<Shirt>> GetAllShirtsWithShop();
    }
}
