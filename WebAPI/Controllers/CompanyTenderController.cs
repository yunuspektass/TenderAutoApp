using Business.DTOs.CompanyTender;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CompanyTenderController:ControllerBase
{
    private readonly ICompanyTenderService _companyTenderService;

    public CompanyTenderController(ICompanyTenderService companyTenderService)
    {
        _companyTenderService = companyTenderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyTenderGetDto>>> GetList()
    {
        var companiesDto = await _companyTenderService.GetList();

        return Ok(companiesDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CompanyTenderGetDto>> GetItem(int id)
    {
        var companyDto = await _companyTenderService.GetItem(id);

        if (companyDto == null)
        {
            return NotFound();
        }

        return Ok(companyDto);
    }

    [HttpPost]
    public async Task<ActionResult<CompanyTenderCreateDto>> PostItem(CompanyTenderCreateDto companyTenderCreateDto)
    {
        var createdCompanyDto = await _companyTenderService.PostItem(companyTenderCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, CompanyTenderUpdateDto companyTenderUpdateDto)
    {
        if (id != companyTenderUpdateDto.Id)
        {
            return BadRequest();
        }

        var result = await _companyTenderService.PutItem(id, companyTenderUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _companyTenderService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}