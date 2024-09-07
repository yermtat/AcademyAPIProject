using AcademyAPI.Data.Models.Academy;
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
    public async Task<IActionResult> AddAcync(string name)
    {
        try
        {
            var res = await _academyService.AddDepartmentAsync(name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("EditDepartment/{id}")]
    public async Task<IActionResult> EditAsync(string id, string name)
    {

        try
        {
            await _academyService.EditDepartmentAsync(id, name);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteDepartment/{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        try
        {
           await _academyService.DeleteDepartmentAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllDepartments")]
    public async Task<List<Department>> GetAllAsync()
    {
        try
        {
            return await _academyService.GetDepartmentsAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
        
    }
}
