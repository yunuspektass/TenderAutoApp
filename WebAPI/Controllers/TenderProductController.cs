using Business.DTOs.TenderProduct;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TenderProductController:ControllerBase
{
    private readonly ITenderProductService  _tenderProductService;

    public TenderProductController(ITenderProductService tenderProductService)
    {
        _tenderProductService = tenderProductService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TenderProductGetDto>>> GetList()
    {
        var tenderProductDtos = await _tenderProductService.GetList();
        return Ok(tenderProductDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TenderProductGetDto>> GetItem(int id)
    {
        var tenderProductDto = await _tenderProductService.GetItem(id);

        if (tenderProductDto == null)
        {
            return NotFound();
        }

        return Ok(tenderProductDto);
    }

    [HttpPost]
    public async Task<ActionResult<TenderProductCreateDto>> PostItem(TenderProductCreateDto tenderProductCreateDto)
    {
        var createdtenderProductList = await _tenderProductService.PostItem(tenderProductCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, TenderProductUpdateDto tenderProductUpdateDto)
    {
        if (id != tenderProductUpdateDto.ProductId && id != tenderProductUpdateDto.TenderId)
        {
            return BadRequest();
        }

        var result = await _tenderProductService.PutItem(id, tenderProductUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _tenderProductService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
