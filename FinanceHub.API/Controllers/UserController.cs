using FinanceGub.Application.Features.UserFeatures.Commands.CreateUserCommand;
using FinanceGub.Application.Features.UserFeatures.Commands.DeleteUserCommand;
using FinanceGub.Application.Features.UserFeatures.Commands.UpdateUserCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetUserQuery;
using FinanceGub.Application.Interfaces.Servises;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
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
        try
        {
            return Ok(await Send(new GetAllUserQuery()));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (RepositoryException ex)
        {
            Logger.LogError(ex, "RepositoryException");
            return StatusCode(500, $"RepositoryException: {ex.Message}");
        }   
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        try
        {
            return Ok(await Send(new GetUserQuery(id)));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (RepositoryException ex)
        {
            Logger.LogError(ex, "RepositoryException");
            return StatusCode(500, $"RepositoryException: {ex.Message}");
        }   
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        try
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (RepositoryException ex)
        {
            Logger.LogError(ex, "Error occurred while creating user");
            return StatusCode(500, $"RepositoryException: {ex.Message}");
        } 
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error occurred while creating user");
            return StatusCode(500, $"Exception: {ex.Message}");
        } 
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest("User ID mismatch.");
        }
    
        try
        {
            var updatedUser = await Send(new UpdateUserCommand(user));
            return Ok(updatedUser);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (RepositoryException ex)
        {
            Logger.LogError(ex, $"Error occurred while updating user with ID {id}");
            return StatusCode(500, $"RepositoryException: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        try
        {
            await Send(new DeleteUserCommand(id));
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (RepositoryException ex)
        {
            Logger.LogError(ex, $"Error occurred while deleting user with ID {id}");
            return StatusCode(500, $"RepositoryException: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}