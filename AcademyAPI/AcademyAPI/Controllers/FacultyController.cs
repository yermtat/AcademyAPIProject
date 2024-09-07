using AcademyAPI.Data.Models.Academy;
using AcademyAPI.Services.Classes;
using AcademyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IAcademyService _academyService;

        public FacultyController(IAcademyService academyService)
        {
            _academyService = academyService;
        }

        [HttpPost("AddFaculty")]
        public async Task<IActionResult> AddAsync([FromBody] Faculty faculty)
        {
            try
            {
                var res = await _academyService.AddFacultyAsync(faculty);
                return Ok(res);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("EditFaculty/{id}")]
        public async Task<IActionResult> EditAsync(string id, [FromBody] Faculty faculty)
        {
            try
            {
                var res = await _academyService.EditFacultyAsync(id, faculty);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteFaculty/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                await _academyService.DeleteFacultytAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllFaculties")]
        public async Task<List<Faculty>> GetAllAsync()
        {
            try
            {
                return await _academyService.GetFacultiesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
