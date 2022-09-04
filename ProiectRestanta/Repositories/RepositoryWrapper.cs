using ProiectRestanta.Data;
using ProiectRestanta.Repositories;

namespace ProiectRestanta.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ProiectContext _context;
        private IUserRepository _user;
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

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
