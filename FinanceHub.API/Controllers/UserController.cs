using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Features.UserFeatures.Commands.DeleteUserCommand;
using FinanceGub.Application.Interfaces.Serviсes;
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
    public async Task<ActionResult<GetUserDto>> GetUser(Guid id)
    {
        var userDto = await _userService.GetUserAsync(id);
        return Ok(userDto); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        var createdUser = await _userService.CreateUserAsync(createUserDto);
        return Created(string.Empty, createdUser);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, UpdateUserDto updateUserDto)
    {
        var updateUser = await _userService.UpdateUserAsync(id, updateUserDto);
        return Ok(updateUser);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var message = await Send(new DeleteUserCommand(id));
        return Content(message); 
    }
}