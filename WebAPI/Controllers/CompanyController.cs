using Business.DTOs.Company;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController:ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetList()
    {
        var companiesDto = await _companyService.GetList();

        return Ok(companiesDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CompanyGetDto>> GetItem(int id)
    {
        var companyDto = await _companyService.GetItem(id);

        if (companyDto == null)
        {
            return NotFound();
        }

        return Ok(companyDto);
    }

    [HttpPost]
    public async Task<ActionResult<CompanyCreateDto>> PostItem(CompanyCreateDto companyCreateDto)
    {
        var createdCompanyDto = await _companyService.PostItem(companyCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, CompanyUpdateDto companyUpdateDto)
    {
        if (id != companyUpdateDto.Id)
        {
            return BadRequest();
        }

        var result = await _companyService.PutItem(id, companyUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _companyService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
    
}