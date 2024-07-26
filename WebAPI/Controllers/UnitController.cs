using Business.DTOs.Unit;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnitController:ControllerBase
{
    private readonly IUnitService  _unitService;

    public UnitController(IUnitService unitService)
    {
        _unitService = unitService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UnitGetDto>>> GetList()
    {
        var unitDtos = await _unitService.GetList();
        return Ok(unitDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UnitGetDto>> GetItem(int id)
    {
        var unitDto = await _unitService.GetItem(id);

        if (unitDto == null)
        {
            return NotFound();
        }

        return Ok(unitDto);
    }

    [HttpPost]
    public async Task<ActionResult<UnitCreateDto>> PostItem(UnitCreateDto unitCreateDto)
    {
        var createdUnit = await _unitService.PostItem(unitCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, UnitUpdateDto unitUpdateDto)
    {
        if (id != unitUpdateDto.Id )
        {
            return BadRequest();
        }

        var result = await _unitService.PutItem(id, unitUpdateDto);

        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _unitService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}