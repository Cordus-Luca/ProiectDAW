using ProiectRestanta.Data;
using ProiectRestanta.Repositories;

namespace ProiectRestanta.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ProiectContext _context;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;
        public RepositoryWrapper(ProiectContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
