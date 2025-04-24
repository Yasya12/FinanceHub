using System.Security.Claims;
using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Features.UserFeatures.Commands.DeleteUserCommand;
using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[Authorize]
public class UserController(IMediator mediator, ILogger<BaseController> logger, IUserService userService)
    : BaseController(mediator, logger)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetUserDto>>> GetAllUser()
    {
        var userDto = await userService.GetAllUsersAsync();
        return Ok(userDto); 
    }

    //Dont use this methid, dont need it
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetUserDto>> GetUser(Guid id)
    {
        var userDto = await userService.GetUserAsync(id);
        return Ok(userDto); 
    }
    
    [HttpGet("by-email")]
    public async Task<ActionResult<GetUserDto>> GetUserByEmail()
    {
        var currentEmail = User.FindFirst(ClaimTypes.Email)?.Value;

        if (currentEmail == null) return BadRequest("No email found in token");
        
        var userDto = await userService.GetUserByEmailAsync(currentEmail);
        return Ok(userDto); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        var createdUser = await userService.CreateUserAsync(createUserDto);
        return Created(string.Empty, createdUser);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;

        if (email == null) return BadRequest("No email found in token");

        if (await userService.UpdateUserAsync(email, updateUserDto)) return NoContent();
        
        return BadRequest("Failed to update user");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var message = await Send(new DeleteUserCommand(id));
        return Content(message); 
    }
}