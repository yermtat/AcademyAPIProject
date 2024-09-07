using Microsoft.AspNetCore.Identity;

namespace AcademyAPI.Data.Models.Auth;

public class User : IdentityUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
