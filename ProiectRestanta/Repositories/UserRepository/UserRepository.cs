using Microsoft.EntityFrameworkCore;
using ProiectRestanta.Data;
using ProiectRestanta.Entities;
using ProiectRestanta.Repositories;

namespace ProiectRestanta.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProiectContext context) : base(context) { }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdWithRoles(int id)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email, StringComparison.Ordinal));
        }
    }
}
