using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Command.CreateCommentCommand;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Comment>
{
    private readonly ICommentRepository _commentRepository;

    public CreateCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public async Task<Comment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        await _commentRepository.AddAsync(request.Comment);
        return request.Comment;
    }
}