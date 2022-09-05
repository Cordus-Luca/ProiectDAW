using ProiectRestanta.Models.Entities.DTOs;

namespace ProiectRestanta.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterUserDTO dto);
        Task<bool> RegisterAdminAsync(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
    }
}
