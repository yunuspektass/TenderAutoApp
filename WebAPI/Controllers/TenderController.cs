using Business.DTOs.Tender;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TenderController:ControllerBase
{
    private readonly ITenderService  _tenderService;

    public TenderController(ITenderService tenderService)
    {
        _tenderService = tenderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TenderGetDto>>> GetList()
    {
        var tenderDtos = await _tenderService.GetList();
        return Ok(tenderDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TenderGetDto>> GetItem(int id)
    {
        var tenderDto = await _tenderService.GetItem(id);

        if (tenderDto == null)
        {
            return NotFound();
        }

        return Ok(tenderDto);
    }

    [HttpPost]
    public async Task<ActionResult<TenderCreateDto>> PostItem(TenderCreateDto tenderCreateDto)
    {
        var createdtenderProductList = await _tenderService.PostItem(tenderCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, TenderUpdateDto tenderUpdateDto)
    {
        if (id != tenderUpdateDto.Id )
        {
            return BadRequest();
        }

        var result = await _tenderService.PutItem(id, tenderUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _tenderService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

}
