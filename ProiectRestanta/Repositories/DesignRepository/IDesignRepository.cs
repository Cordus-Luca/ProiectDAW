using ProiectRestanta.Entities;

namespace ProiectRestanta.Repositories.DesignRepository
{
    public interface IDesignRepository : IGenericRepository<Design>
    {
        Task<Design> GetByModel(string name);
        Task<List<Design>> GetAllDesignsWithColor();
    }
}
