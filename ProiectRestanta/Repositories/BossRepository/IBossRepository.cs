using ProiectRestanta.Entities;

namespace ProiectRestanta.Repositories.BossRepository
{
    public interface IBossRepository : IGenericRepository<Boss>
    {
        Task<Boss> GetByName(string name);
        Task<List<Boss>> GetAllWithShop();

    }
}
