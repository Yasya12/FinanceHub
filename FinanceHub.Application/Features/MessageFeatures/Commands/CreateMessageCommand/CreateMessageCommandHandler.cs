using FinanceGub.Application.Features.PostFeatures.Commands.CreatePostCommand;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Commands.CreateMessageCommand;

public class CreateMessageCommandHandler(IMessageRepository messageRepository): IRequestHandler< CreateMessageCommand, Message>
{
    public async Task<Message> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        await messageRepository.AddAsync(request.Message);
        return request.Message;
    }
}