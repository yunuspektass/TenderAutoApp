using Business.DTOs.Offer;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfferController:ControllerBase
{
    private readonly IOfferService _offerService;

    public OfferController(IOfferService offerService)
    {
        _offerService = offerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OfferGetDto>>> GetList()
    {
        var offersDto = await _offerService.GetList();

        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OfferGetDto>> GetItem(int id)
    {
        var offerDto = await _offerService.GetItem(id);

        if (offerDto == null)
        {
            return NotFound();
        }

        return Ok(offerDto);
    }

    [HttpPost]
    public async Task<ActionResult<OfferCreateDto>> PostItem(OfferCreateDto offerCreateDto)
    {
        var createdOfferDto = await _offerService.PostItem(offerCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, OfferUpdateDto offerUpdateDto)
    {
        if (id != offerUpdateDto.Id)
        {
            return BadRequest();
        }

        var result = await _offerService.PutItem(id, offerUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _offerService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
    
}