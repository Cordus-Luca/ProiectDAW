using Microsoft.EntityFrameworkCore;
using ProiectRestanta.Data;
using ProiectRestanta.Entities;
using System.Drawing;

namespace ProiectRestanta.Repositories.DesignRepository
{
    public class DesignRepository : GenericRepository<Design>, IDesignRepository
    {
        public DesignRepository(ProiectContext context) : base(context) { }
        public async Task<List<Design>> GetAllDesignsWithColor()
        {
            return await _context.Designs.Include(d => d.Culoare).ToListAsync();
        }

        public async Task<Design> GetByModel(string model)
        {
            return await _context.Designs.Where(d => d.Model.Equals(model, StringComparison.Ordinal)).FirstOrDefaultAsync();
        }
    }
}
