using Business.DTOs.User;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController:ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserGetDto>>> GetList()
    {
        var userDtos = await _userService.GetList();

        return Ok(userDtos);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserGetDto>> GetItem(int id)
    {
        var userDto = await _userService.GetItem(id);

        if (userDto == null)
        {
            return NotFound();
        }

        return Ok(userDto);
    }

    [HttpPost]
    public async Task<ActionResult<UserCreateDto>> PostItem(UserCreateDto userCreateDto)
    {
        var createdUser = await _userService.PostItem(userCreateDto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, UserUpdateDto userUpdateDto)
    {
        if (id != userUpdateDto.Id )
        {
            return BadRequest();
        }

        var result = await _userService.PutItem(id, userUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _userService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

}
