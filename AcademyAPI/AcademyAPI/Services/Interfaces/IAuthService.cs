using AcademyAPI.Data.Models.Auth;

namespace AcademyAPI.Services.Interfaces;

public interface IAuthService
{
    public Task<User> RegisterUserAsync(RegisterUser user);
}
