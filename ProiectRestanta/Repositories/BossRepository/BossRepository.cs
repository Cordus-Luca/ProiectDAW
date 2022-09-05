using Microsoft.EntityFrameworkCore;
using ProiectRestanta.Data;
using ProiectRestanta.Entities;

namespace ProiectRestanta.Repositories.BossRepository
{
    public class BossRepository : GenericRepository<Boss>, IBossRepository
    {
        public BossRepository(ProiectContext context) : base(context) { }

        public async Task<List<Boss>> GetAllWithShop()
        {
            return await _context.Bosses.Include(b => b.Shop).ToListAsync();
        }

        public async Task<Boss> GetByName(string name)
        {
            return await _context.Bosses.Where(b => b.Nume.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
