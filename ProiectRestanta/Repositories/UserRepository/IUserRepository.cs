using ProiectRestanta.Entities;
using ProiectRestanta.Repositories;

namespace ProiectRestanta.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByEmail(string email);   
    }
}
