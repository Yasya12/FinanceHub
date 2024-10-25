using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Features.UserFeatures.Commands.DeleteUserCommand;
using FinanceGub.Application.Features.UserFeatures.Commands.UpdateUserCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetUserQuery;
using FinanceGub.Application.Interfaces.Serviсes;
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
    public async Task<ActionResult<IEnumerable<GetUserDto>>> GetAllUser()
    {
        var userDto = await _userService.GetAllUsersAsync();
        return Ok(userDto); 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        return Ok(await Send(new GetUserQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        var createdUser = await _userService.CreateUserAsync(createUserDto);
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