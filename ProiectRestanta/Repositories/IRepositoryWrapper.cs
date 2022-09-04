using ProiectRestanta.Repositories;

namespace ProiectRestanta.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get;  }

        Task SaveAsync();
    }
}
