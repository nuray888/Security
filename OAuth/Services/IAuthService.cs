using OAuth.Entities;
using OAuth.Entities.Models;

namespace OAuth.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<TokenResponseDto?> LoginAsync(UserDto request);
    }
}
