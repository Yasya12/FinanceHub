using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Features.PhotoFeatures.Commands.CreateUserPhotoCommand;
using FinanceGub.Application.Features.PhotoFeatures.Commands.DeletePhotoCommand;
using FinanceGub.Application.Features.UserFeatures.Commands.DeleteUserCommand;
using FinanceGub.Application.Features.UserFeatures.Commands.UpdateUserCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

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
    
    [HttpGet("by-username/{username}")]
    public async Task<ActionResult<GetUserDto>> GetUserByUsername(string username)
    {
        var userDto = await userService.GetUserByUsernameAsync(username);
        return Ok(userDto);
    }

    [Authorize]
    [HttpGet("by-email")]
    public async Task<ActionResult<GetUserDto>> GetUserByEmail()
    {
        var userDto = await userService.GetUserByEmailAsync(User.GetEmail());
        return Ok(userDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        var createdUser = await userService.CreateUserAsync(createUserDto);
        return Created(string.Empty, createdUser);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
    {
        if (await userService.UpdateUserAsync(User.GetEmail(), updateUserDto)) return NoContent();

        return BadRequest("Failed to update user");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var message = await Send(new DeleteUserCommand(id));
        return Content(message);
    }

    [Authorize]
    [HttpPost("add-photo")]
    public async Task<ActionResult<string>> AddPhoto(IFormFile file)
    {
        var user = await mediator.Send(new GetByEmailUserQuery(User.GetEmail()));

        if (user == null) return BadRequest("User not found");

        var photoUrl = await mediator.Send(new CreateUserPhotoCommand(file));

        if (photoUrl == null) return BadRequest("Error adding a photo");

        var oldPhotoUrl = user.ProfilePictureUrl;
        
        user.ProfilePictureUrl = photoUrl;

        await mediator.Send(new UpdateUserCommand(user));
        
        if (!string.IsNullOrEmpty(oldPhotoUrl))
        {
            // Best practice: wrap delete in try-catch in case something goes wrong
            try
            {
                await mediator.Send(new DeletePhotoCommand(oldPhotoUrl));
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error during user creation.", ex);
                // Log error if necessary, but don't crash
                // _logger.LogError(ex, "Failed to delete old photo");
            }
        }

        return Ok(new { photoUrl });
    }
    
    [Authorize]
    [HttpDelete("delete-photo")]
    public async Task<IActionResult> DeletePhoto()
    {
        var user = await mediator.Send(new GetByEmailUserQuery(User.GetEmail()));

        if (user == null) return BadRequest("User not found");

        if (String.IsNullOrEmpty(user.ProfilePictureUrl)) return BadRequest("No profile picture was found");

        await Send(new DeletePhotoCommand(user.ProfilePictureUrl));

        user.ProfilePictureUrl = null;
        await mediator.Send(new UpdateUserCommand(user));
        return Ok();
    }
}