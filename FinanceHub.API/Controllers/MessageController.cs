using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Extensions;
using FinanceGub.Application.Features.MessageFeatures.Queries.GetMessagesForUser;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

public class MessageController(IMediator mediator, ILogger<BaseController> logger, IMessageService messageService)
    : BaseController(mediator, logger)
{
    [HttpPost]
    public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto)
    {
        var message = await messageService.CreateMessage(createMessageDto);
        return Created(string.Empty, message);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesForUser([FromQuery] MessageParams messageParams)
    {
        var messages = await mediator.Send(new GetMessagesForUser(messageParams));
        
        Response.AddPaginationHeader(messages);

        return messages;
    }
}