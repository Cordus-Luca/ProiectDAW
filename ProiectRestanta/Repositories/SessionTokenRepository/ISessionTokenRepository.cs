using ProiectRestanta.Models.Entities;

namespace ProiectRestanta.Repositories
{
    public interface ISessionTokenRepository : IGenericRepository<SessionToken>
    {
        Task<SessionToken> GetByJti(string jti);
    }
}
