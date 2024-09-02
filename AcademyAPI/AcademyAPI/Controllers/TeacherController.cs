using AcademyAPI.Data.Models;
using AcademyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly IAcademyService _academyService;

    public TeacherController(IAcademyService academyService)
    {
        _academyService = academyService;
    }

    [HttpPost("AddTeacher")]
    public async Task<IActionResult> AddAsync([FromBody] Teacher teacher)
    {
        try
        {
            var res = await _academyService.AddTeacherAsync(teacher);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("EditTeacher/{id}")]
    public async Task<IActionResult> EditAsync(string id, [FromBody] Teacher teacher)
    {
        try
        {
            var res = await _academyService.EditTeacherAsync(id, teacher);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteTeacher/{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        try
        {
            await _academyService.DeleteTeacherAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllTeachers")]
    public async Task<List<Teacher>> GetAllAsync()
    {
        try
        {
            return await _academyService.GetTeachersAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}

