using Business.DTOs.UserRole;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRoleController:ControllerBase
{
    private readonly IUserRoleService _userRoleService;

    public UserRoleController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserRoleGetDto>>> GetList()
    {
        var userRoleDtos = await _userRoleService.GetList();

        return Ok(userRoleDtos);
    }

    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserRoleGetDto>> GetItem(int id)
    {
        var userRoleDto = await _userRoleService.GetItem(id);

        if (userRoleDto == null)
        {
            return NotFound();
        }

        return Ok(userRoleDto);
    }

    [HttpPost]
    public async Task<ActionResult<UserRoleCreateDto>> PostItem(UserRoleCreateDto userRoleCreateDto)
    {
        var createdRoleCreateDto = await _userRoleService.PostItem(userRoleCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, UserRoleUpdateDto userRoleUpdateDto)
    {
        if (id != userRoleUpdateDto.UserId )
        {
            return BadRequest();
        }

        var result = await _userRoleService.PutItem(id, userRoleUpdateDto);

        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _userRoleService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}