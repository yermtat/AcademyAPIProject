using AcademyAPI.Data.Models.Auth;
using AcademyAPI.Services.Interfaces;
using AcademyAPI.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AcademyAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly LoginUserValidator _loginUserValidator;
    private readonly RegistrationUserValidator _registrationUserValidator;

    public AuthController(IAuthService authService, LoginUserValidator loginUserValidator, RegistrationUserValidator registrationUserValidator)
    {
        _authService = authService;
        _loginUserValidator = loginUserValidator;
        _registrationUserValidator = registrationUserValidator;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUser user)
    {
        try
        {
            var validationRes = _registrationUserValidator.Validate(user);
            if (!validationRes.IsValid) return BadRequest(validationRes.Errors);

            var result = await _authService.RegisterUserAsync(user);
            return Ok(result);
        }
        catch (Exception ex) 
        {
            return BadRequest(ex.Message);     
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUser user)
    {
        try
        {
            var validationRes = _loginUserValidator.Validate(user);
            if (!validationRes.IsValid) BadRequest(validationRes.Errors);

            var result = await _authService.LoginUserAsync(user);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Refresh")]
    public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshUser refresh)
    {
        try
        {
            var newToken = await _authService.RefreshTokenAsync(refresh);

            if (newToken == null) return BadRequest("Invalid token");

            return Ok(newToken);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> LogoutAsync([FromBody] TokenData token)
    {
        try
        {
            await _authService.LogoutAsync(token);
            return Ok("Logout successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
