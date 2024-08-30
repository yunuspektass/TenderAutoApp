using Business.DTOs.Permission;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PermissionGetDto>>> GetList()
    {
        var permissionDtos = await _permissionService.GetList();
        return Ok(permissionDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PermissionGetDto>> GetItem(int id)
    {
        var permissionDto = await _permissionService.GetItem(id);

        if (permissionDto == null)
        {
            return NotFound();
        }

        return Ok(permissionDto);
    }

    [HttpPost]
    public async Task<ActionResult<PermissionCreateDto>> PostItem(PermissionCreateDto permissionCreateDto)
    {
        var createdPermissionDto = await _permissionService.PostItem(permissionCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem( int id ,PermissionUpdateDto permissionUpdateDto)
    {
        if (id != permissionUpdateDto.Id)
        {
            return BadRequest();
        }

        var result = await _permissionService.PutItem(id, permissionUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _permissionService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}