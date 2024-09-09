using AcademyAPI.Data.Models.Auth;
using System.Security.Claims;

namespace AcademyAPI.Services.Interfaces;

public interface ITokenService
{
    public Task<string> GenerateTokenAsync(User user);
    public Task<string> GenerateRefreshTokenAsync();
    public ClaimsPrincipal GetPrincipalFromToken(string token);
}
