using AcademyAPI.Data.Models;
using AcademyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IAcademyService _academyService;

    public StudentController(IAcademyService academyService)
    {
        _academyService = academyService;
    }

    [HttpPost("AddStudent")]
    public async Task<IActionResult> AddAsync([FromBody] Student student)
    {
        try
        {
            var result = await _academyService.AddStudentAsync(student);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("EditStudent/{id}")]
    public async Task<IActionResult> EditAsync(string id, [FromBody] Student student)
    {
        try
        {
            var result = await _academyService.EditStudentAsync(id, student);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteStudent/{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        try
        {
            await _academyService.DeleteStudentAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllStudents")]
    public async Task<ActionResult<List<Student>>> GetAllAsync()
    {
        try
        {
            var students = await _academyService.GetStudentsAsync();
            return Ok(students);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
