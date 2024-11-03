using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Command.DeleteCommentCommand;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, string>
{
    private readonly ICommentRepository _commentRepository;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public async Task<string> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(request.Id);

        if (comment == null)
        {
            throw new NotFoundException($"Comment with ID {request.Id} not found.");
        }
        
        var message = await _commentRepository.DeleteAsync(request.Id);
        return message;
    }
}