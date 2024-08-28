using AcademyAPI.Data.Models;
using AcademyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AcademyAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IAcademyService _academyService;

    public DepartmentController(IAcademyService academyService)
    {
        _academyService = academyService;
    }

    [HttpPost("AddDepartment")]
    public async Task<IActionResult> AddDepartmentAcync(string name)
    {
        var res = await _academyService.AddDepartmentAsync(name);
        return Ok(res);
    }
}
