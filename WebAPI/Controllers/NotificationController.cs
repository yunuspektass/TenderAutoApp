using Business.DTOs.Notification;
using Business.GenericRepository.BaseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController:ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotificationGetDto>>> GetList()
    {
        var notificationsDto = await _notificationService.GetList();

        return Ok(notificationsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<NotificationGetDto>> GetItem(int id)
    {
        var notificationDto = await _notificationService.GetItem(id);

        if (notificationDto == null)
        {
            return NotFound();
        }

        return Ok(notificationDto);
    }




    [HttpPost]
    public async Task<ActionResult<NotificationCreateDto>> PostItem(NotificationCreateDto notificationCreateDto)
    {
        var createdNotificationDto = await _notificationService.PostItem(notificationCreateDto);

        return Ok(createdNotificationDto);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutItem(int id, NotificationUpdateDto notificationUpdateDto)
    {
        if (id != notificationUpdateDto.Id)
        {
            return BadRequest();
        }

        var result = await _notificationService.PutItem(id, notificationUpdateDto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _notificationService.DeleteItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

}
