using FinanceGub.Application.Features.UserFeatures.Commands.DeleteUserCommand;
using FinanceGub.Application.Features.UserFeatures.Commands.UpdateUserCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetUserQuery;
using FinanceGub.Application.Interfaces.Servises;
using FinanceHub.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController
{
    private readonly IUserService _userService;
    public UserController(IMediator mediator, ILogger<BaseController> logger, IUserService userService) : base(mediator, logger)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
    {
        return Ok(await Send(new GetAllUserQuery())); 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        return Ok(await Send(new GetUserQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        var createdUser = await _userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest("User ID mismatch.");
        }
    
        return Ok(await Send(new UpdateUserCommand(user)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await Send(new DeleteUserCommand(id));
        return NoContent();
    }
}