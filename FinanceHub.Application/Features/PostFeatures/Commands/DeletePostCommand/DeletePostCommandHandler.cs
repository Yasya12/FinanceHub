using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Commands.DeletePostCommand;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, string>
{
    private readonly IPostRepository _postRepository;

    public DeletePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public async Task<string> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id);

        if (post == null)
        {
            throw new NotFoundException($"Post with ID {request.Id} not found.");
        }
        
        var message = await _postRepository.DeleteAsync(request.Id);
        return message;
    }
}