using AcademyAPI.Data.Contexts;
using AcademyAPI.Data.Models.Auth;
using AcademyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using System.Security.Claims;
using static BCrypt.Net.BCrypt;

namespace AcademyAPI.Services.Classes;

public class AuthService : IAuthService
{ 
    private readonly AuthContext _authContext;
    private readonly ITokenService _tokenService;

    public AuthService(AuthContext authContext, ITokenService tokenService)
    {
        _authContext = authContext;
        _tokenService = tokenService;
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

    public async Task<TokenData> LoginUserAsync(LoginUser user)
    {
        try
        {
            var foundUser = await _authContext.Users.FirstOrDefaultAsync(x => x.Username == user.Username);

            if (foundUser == null) throw new Exception("User is not found");

            if (!Verify(user.Password, foundUser.Password)) throw new Exception("Invalid password");

            var tokenData = new TokenData()
            {
                AccessToken = await _tokenService.GenerateTokenAsync(foundUser),
                RefreshToken = await _tokenService.GenerateRefreshTokenAsync(),
                RefreshTokenExpireTime = DateTime.Now.AddDays(1)
            };

            foundUser.RefreshToken = tokenData.RefreshToken;
            foundUser.RefreshTokenExpiryTime = tokenData.RefreshTokenExpireTime;

            await _authContext.SaveChangesAsync();

            return tokenData;
      
        }
        catch
        {
            throw;
        }
    }

    public async Task<TokenData> RefreshTokenAsync(RefreshUser userAccessData)
    {
        if (userAccessData == null)
            throw new Exception("Invalid client request");

        var accessToken = userAccessData.AccessToken;
        var refreshToken = userAccessData.RefreshToken;

        var principal = _tokenService.GetPrincipalFromToken(accessToken);

        var username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var user = _authContext.Users.FirstOrDefault(u => u.Username == username);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new Exception("Invalid client request");

        var newAccessToken = await _tokenService.GenerateTokenAsync(user);
        var newRefreshToken = await _tokenService.GenerateRefreshTokenAsync();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);

        await _authContext.SaveChangesAsync();

        return new TokenData
        {

            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            RefreshTokenExpireTime = user.RefreshTokenExpiryTime
        };
    }

}
