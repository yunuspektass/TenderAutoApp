using Business.DTOs.TenderStatus;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "TenderResponsible")]
public class TenderStatusController:ControllerBase
{
    private readonly ITenderStatusService _tenderStatusService;

    public TenderStatusController(ITenderStatusService tenderStatusService)
    {
        _tenderStatusService = tenderStatusService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TenderStatusGetDto>>> GetList()
    {
        var tenderStatusDtos = await _tenderStatusService.GetList();

        return Ok(tenderStatusDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TenderStatusGetDto>> GetItem(int id)
    {
        var tenderStatusDto = await _tenderStatusService.GetItem(id);

        if (tenderStatusDto == null )
        {
            return NotFound();
        }

        return Ok(tenderStatusDto);
    }

    [HttpPost]
    public async Task<ActionResult<TenderStatusCreateDto>> PostItem(
        TenderStatusCreateDto tenderStatusCreateDto)
    {
        var createdTenderStatus = await _tenderStatusService.PostItem(tenderStatusCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, TenderStatusUpdateDto tenderStatusUpdateDto)
    {
        if (id != tenderStatusUpdateDto.Id )
        {
            return BadRequest();
        }

        var result = await _tenderStatusService.PutItem(id, tenderStatusUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _tenderStatusService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
    
}