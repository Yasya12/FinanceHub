using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Commands.UpdateCommentCommand;

public class UpdateCommentCommandHandler : IRequestHandler<Commands.UpdateCommentCommand.UpdateCommentCommand, Comment>
{
    private readonly ICommentRepository _commentRepository;

    public UpdateCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public async Task<Comment> Handle(Commands.UpdateCommentCommand.UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(request.Comment.Id);

        if (comment == null)
        {
            throw new NotFoundException($"Comment with ID {request.Comment.Id} not found.");
        }
        
        await _commentRepository.UpdateAsync(request.Comment);
        return request.Comment;
    }
}