using AcademyAPI.Data.Models.Auth;
using AcademyAPI.Services.Interfaces;
using AcademyAPI.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AcademyAPI.Controllers
{
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
    }
}
