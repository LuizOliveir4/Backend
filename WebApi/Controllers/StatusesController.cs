using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusesController(StatusService statusService) : ControllerBase
{
    private readonly StatusService _statusService = statusService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var statuses = await _statusService.GetAllStatusesAsync();
        return Ok(statuses);
    }
}