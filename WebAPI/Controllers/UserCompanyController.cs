using Business.DTOs.UserCompany;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserCompanyController:ControllerBase
{
    private readonly IUserCompanyService _userCompanyService;

    public UserCompanyController(IUserCompanyService userCompanyService)
    {
        _userCompanyService = userCompanyService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserCompanyGetDto>>> GetList()
    {
        var userCompanyDtos = await _userCompanyService.GetList();

        return Ok(userCompanyDtos);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserCompanyGetDto>> GetItem(int id)
    {
        var userCompanyDto = await _userCompanyService.GetItem(id);

        if (userCompanyDto == null)
        {
            return NotFound();
        }

        return Ok(userCompanyDto);
    }

    [HttpPost]
    public async Task<ActionResult<UserCompanyCreateDto>> PostItem(UserCompanyCreateDto userCompanyCreateDto)
    {
        var createdUserCompany = await _userCompanyService.PostItem(userCompanyCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, UserCompanyUpdateDto userCompanyUpdateDto)
    {
        if (id != userCompanyUpdateDto.Id )
        {
            return BadRequest();
        }

        var result = await _userCompanyService.PutItem(id, userCompanyUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _userCompanyService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }


    [HttpDelete("user/{userId}")]
    public async Task<IActionResult> DeleteUserCompaniesByUserId(int userId)
    {
        var result = await _userCompanyService.DeleteUserCompaniesByUserId(userId);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }


}
