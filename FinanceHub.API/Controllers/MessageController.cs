using System.Security.Claims;
using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Extensions;
using FinanceGub.Application.Features.MessageFeatures.Commands.DeleteMessageCommand;
using FinanceGub.Application.Features.MessageFeatures.Commands.UpdateMessageCommand;
using FinanceGub.Application.Features.MessageFeatures.Queries.GetMessageById;
using FinanceGub.Application.Features.MessageFeatures.Queries.GetMessagesForUser;
using FinanceGub.Application.Features.MessageFeatures.Queries.GetMessageThread;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Extensions;
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
        var senderEmail = User.GetEmail();

        if (senderEmail == null) return BadRequest("No email found in token");

        var message = await messageService.CreateMessage(createMessageDto, senderEmail);
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
    public async Task<ActionResult<PagedList<MessageDto>>> GetMessageThread(string username, [FromQuery] MessageThreadParams messageThreadParams)
    {
        var currentEmail = User.FindFirst(ClaimTypes.Email)?.Value;

        if (currentEmail == null) return BadRequest("No email found in token");

        var user = await mediator.Send(new GetByEmailUserQuery(currentEmail));
        var currentUsername = user.Username;

        var messagesThread = await mediator.Send(new GetMessageThread(currentUsername, username, messageThreadParams));
        
        Response.AddPaginationHeader(messagesThread);

        return messagesThread;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMessage(Guid id)
    {
        var email = User.GetEmail();
        var user = await mediator.Send(new GetByEmailUserQuery(email));

        var message = await mediator.Send(new GetMessageById(id));

        if (message == null) return BadRequest("Cannot delete this message");

        if (message.SenderUserName != user.Username && message.RecipientUserName != user.Username) return Forbid();

        if (message.SenderUserName == user.Username) message.SenderDeleted = true;
        if (message.RecipientUserName == user.Username) message.RecipientDeleted = true;
        
        await mediator.Send(new UpdateMessageCommand(message));

        if (message is { SenderDeleted: true, RecipientDeleted: true })
        {
            await mediator.Send(new DeleteMessageCommand(id));
        }
        
        return Ok();
    }
}