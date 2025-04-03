using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController(MemberService memberService) : ControllerBase
{
    private readonly MemberService _memberService = memberService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var members = await _memberService.GetAllUsersAsync();
        return Ok(members);
    }
}
