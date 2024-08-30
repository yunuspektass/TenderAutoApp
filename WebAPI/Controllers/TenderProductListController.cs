using Business.DTOs.Product;
using Business.DTOs.TenderProductListGetDto;
using Business.DTOs.Urun;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "TenderResponsible")]
public class TenderProductListController:ControllerBase
{
    private readonly ITenderProductListService _tenderProductListService;

    public TenderProductListController(ITenderProductListService tenderProductListService)
    {
        _tenderProductListService = tenderProductListService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TenderProductListGetDto>>> GetList()
    {
        var tenderProductListDtos = await _tenderProductListService.GetList();
        return Ok(tenderProductListDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TenderProductListGetDto>> GetItem(int id)
    {
        var tenderProductListDto = await _tenderProductListService.GetItem(id);

        if (tenderProductListDto == null)
        {
            return NotFound();
        }

        return Ok(tenderProductListDto);
    }

    [HttpPost]
    public async Task<ActionResult<TenderProductListCreateDto>> PostItem(TenderProductListCreateDto tenderProductListCreate)
    {
        var createdtenderProductList = await _tenderProductListService.PostItem(tenderProductListCreate);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, TenderProductListUpdateDto tenderProductListUpdateDto)
    {
        if (id != tenderProductListUpdateDto.Id)
        {
            return BadRequest();
        }

        var result = await _tenderProductListService.PutItem(id, tenderProductListUpdateDto);

        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _tenderProductListService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}