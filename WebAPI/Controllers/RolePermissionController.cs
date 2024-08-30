using Business.DTOs.RolePermission;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolePermissionController:ControllerBase
{
    private readonly IRolePermissionService _rolePermissionService;

    public RolePermissionController(IRolePermissionService rolePermissionService)
    {
        _rolePermissionService = rolePermissionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RolePermissionGetDto>>> GetList()
    {
        var rolePermissionDtos = await _rolePermissionService.GetList();

        return Ok(rolePermissionDtos);
    }

    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<RolePermissionGetDto>> GetItem(int id)
    {
        var rolePermissionDto = await _rolePermissionService.GetItem(id);

        if (rolePermissionDto == null)
        {
            return NotFound();
        }

        return Ok(rolePermissionDto);
    }

    [HttpPost]
    public async Task<ActionResult<RolePermissionCreateDto>> PostItem(RolePermissionCreateDto rolePermissionCreateDto)
    {
        var createdRolePermission = await _rolePermissionService.PostItem(rolePermissionCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, RolePermissionUpdateDto rolePermissionUpdateDto)
    {
        if (id != rolePermissionUpdateDto.PermissionId )
        {
            return BadRequest();
        }

        var result = await _rolePermissionService.PutItem(id, rolePermissionUpdateDto);

        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _rolePermissionService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}