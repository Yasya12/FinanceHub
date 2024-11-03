using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Command.UpdateCommentCommand;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Comment>
{
    private readonly ICommentRepository _commentRepository;

    public UpdateCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public async Task<Comment> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
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