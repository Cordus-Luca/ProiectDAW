using Microsoft.EntityFrameworkCore;
using ProiectRestanta.Data;
using ProiectRestanta.Models.Entities;

namespace ProiectRestanta.Repositories
{
    public class SessionTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(ProiectContext context) : base(context) { }

        public async Task<SessionToken> GetByJti(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
