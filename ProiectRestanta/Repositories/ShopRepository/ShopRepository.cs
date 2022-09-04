using Microsoft.EntityFrameworkCore;
using ProiectRestanta.Data;
using ProiectRestanta.Entities;
using ProiectRestanta.Repositories;

namespace ProiectRestanta.Repositories.ShopRepository
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(ProiectContext context) : base(context) { }

        public async Task<List<Shop>> GetAllShopsWithStock()
        {
            return await _context.Shops.Where(s => s.Stoc > 0).ToListAsync();
        }

        public async Task<Shop> GetByName(string name)
        {
            return await _context.Shops.Where(s => s.Nume.Equals(name, StringComparison.Ordinal)).FirstOrDefaultAsync();
        }
    }
}
