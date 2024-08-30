using Business.DTOs.UserTender;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserTenderController:ControllerBase
{
    private readonly IUserTenderService _userTenderService;

    public UserTenderController(IUserTenderService userTenderService)
    {
        _userTenderService = userTenderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserTenderGetDto>>> GetList()
    {
        var userTenderDtos = await _userTenderService.GetList();

        return Ok(userTenderDtos);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserTenderGetDto>> GetItem(int id)
    {
        var userTenderDto = await _userTenderService.GetItem(id);

        if (userTenderDto == null)
        {
            return NotFound();
        }

        return Ok(userTenderDto);
    }

    [HttpPost]
    public async Task<ActionResult<UserTenderCreateDto>> PostItem(UserTenderCreateDto userTenderCreateDto)
    {
        var createdUserTender = await _userTenderService.PostItem(userTenderCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, UserTenderUpdateDto userTenderUpdateDto)
    {
        if (id != userTenderUpdateDto.Id )
        {
            return BadRequest();
        }

        var result = await _userTenderService.PutItem(id, userTenderUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _userTenderService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("user/{userId}")]
    public async Task<IActionResult> DeleteUserTendersByUserId(int userId)
    {
        var result = await _userTenderService.DeleteUserTendersByUserId(userId);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

}
