using Microsoft.EntityFrameworkCore;
using ProiectRestanta.Data;
using ProiectRestanta.Entities;
using ProiectRestanta.Models.Entities.DTOs;
using ProiectRestanta.Repositories;
using System.Linq;

namespace ProiectRestanta.Repositories.ShopRepository
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(ProiectContext context) : base(context) { }

        public async Task<List<Shop>> GetAllShopsWithStock()
        {
            return await _context.Shops.Include(s => s.Stoc).ToListAsync();
        }

        public async Task<Shop> GetByName(string name)
        {
            return await _context.Shops.Where(s => s.Nume.Equals(name, StringComparison.Ordinal)).FirstOrDefaultAsync();
        }

        public async Task<List<ShopSalaryDTO>> GetJoinedShopSalary()
        {
            return await _context.Shops.Join(_context.Bosses, s => s.BossId, b => b.Id, (s, b) => new ShopSalaryDTO(s.Nume, b.Salariu)).ToListAsync();
        }
    }
}
