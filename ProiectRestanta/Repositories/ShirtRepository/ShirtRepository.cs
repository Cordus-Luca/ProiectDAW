using Microsoft.EntityFrameworkCore;
using ProiectRestanta.Data;
using ProiectRestanta.Entities;
using System.Xml.Linq;

namespace ProiectRestanta.Repositories.ShirtRepository
{
    public class ShirtRepository : GenericRepository<Shirt>, IShirtRepository
    {
        public ShirtRepository(ProiectContext context) : base(context) { }
        public async Task<List<Shirt>> GetAllShirtsWithShop()
        {
            return await _context.Shirts.Include(sh => sh.Shop).ToListAsync();
        }

        public async Task<Shirt> GetByColor(string color)
        {
            return await _context.Shirts.Where(sh => sh.Culoare.Equals(color, StringComparison.Ordinal)).FirstOrDefaultAsync();
        }
    }
}
