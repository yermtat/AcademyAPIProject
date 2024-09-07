using AcademyAPI.Data.Models.Academy;
using AcademyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController : ControllerBase
{
    private readonly IAcademyService _academyService;

    public GroupController(IAcademyService academyService)
    {
        _academyService = academyService;
    }

    [HttpPost("AddGroup")]
    public async Task<IActionResult> AddAsync([FromBody] Group group)
    {
        try
        {
            var result = await _academyService.AddGroupAsync(group);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("EditGroup/{id}")]
    public async Task<IActionResult> EditAsync(string id, [FromBody] Group group)
    {
        try
        {
            var result = await _academyService.EditGroupAsync(id, group);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteGroup/{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        try
        {
            await _academyService.DeleteGroupAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllGroups")]
    public async Task<ActionResult<List<Group>>> GetAllAsync()
    {
        try
        {
            var groups = await _academyService.GetGroupsAsync();
            return Ok(groups);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("ChangeTeacher/{groupId}")]
    public async Task<IActionResult> ChangeTeacherAsync(string groupId, string teacherId)
    {
        try
        {
            var res =_academyService.ChangeGroupTeacherAsync(groupId, teacherId);
            return Ok(res);
             
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

