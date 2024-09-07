using AcademyAPI.Data.Contexts;
using AcademyAPI.Data.Models.Auth;
using AcademyAPI.Services.Interfaces;
using Microsoft.OpenApi.Validations;
using static BCrypt.Net.BCrypt;

namespace AcademyAPI.Services.Classes;

public class AuthService : IAuthService
{ 
    private readonly AuthContext _authContext;

    public AuthService(AuthContext authContext)
    {
        _authContext = authContext;
    }


    public async Task<User> RegisterUserAsync(RegisterUser user)
    {
        try
        {
            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = HashPassword(user.Password)
            };

            await _authContext.Users.AddAsync(newUser);
            await _authContext.SaveChangesAsync();

            return newUser;
        }
        catch
        {
            throw;
        }
    }
}
