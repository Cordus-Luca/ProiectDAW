using ProiectRestanta.Repositories;

namespace ProiectRestanta.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get;  }
        ISessionTokenRepository SessionToken { get; }

        Task SaveAsync();
    }
}
