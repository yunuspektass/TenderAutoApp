using Business.DTOs.Role;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController: ControllerBase
{
    
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleGetDto>>> GetList()
    {
        var roleDtos = await _roleService.GetList();

        return Ok(roleDtos);
    }

    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<RoleGetDto>> GetItem(int id)
    {
        var roleDto = await _roleService.GetItem(id);

        if (roleDto == null)
        {
            return NotFound();
        }

        return Ok(roleDto);
    }

    [HttpPost]
    public async Task<ActionResult<RoleCreateDto>> PostItem(RoleCreateDto roleCreateDto)
    {
        var createdUnit = await _roleService.PostItem(roleCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, RoleUpdateDto roleUpdateDto)
    {
        if (id != roleUpdateDto.Id )
        {
            return BadRequest();
        }

        var result = await _roleService.PutItem(id, roleUpdateDto);

        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _roleService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

}