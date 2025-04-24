using System.Security.Claims;
using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Extensions;
using FinanceGub.Application.Features.MessageFeatures.Queries.GetMessagesForUser;
using FinanceGub.Application.Features.MessageFeatures.Queries.GetMessageThread;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[Authorize]
public class MessageController(IMediator mediator, ILogger<BaseController> logger, IMessageService messageService)
    : BaseController(mediator, logger)
{
    [HttpPost]
    public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto)
    {
        var senderUsername = User.FindFirst(ClaimTypes.Name)?.Value;

        if (senderUsername == null) return BadRequest("No email found in token");
        
        var message = await messageService.CreateMessage(createMessageDto, senderUsername);
        return Created(string.Empty, message);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesForUser([FromQuery] MessageParams messageParams)
    {
        var messages = await mediator.Send(new GetMessagesForUser(messageParams));
        
        Response.AddPaginationHeader(messages);

        return messages;
    }

    [HttpGet("thread/{username}")]

    public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessageThread(string username)
    {
        var currentEmail = User.FindFirst(ClaimTypes.Email)?.Value;

        if (currentEmail == null) return BadRequest("No email found in token");

        var user = await mediator.Send(new GetByEmailUserQuery(currentEmail));
        var currentUsername = user.Username;
        
        return Ok(await mediator.Send(new GetMessageThread(currentUsername, username)));
    }
}