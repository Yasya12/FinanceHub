using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Commands.UpdatePostCommand;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Post>
{
    private readonly IPostRepository _postRepository;

    public UpdatePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var profile = await _postRepository.GetByIdAsync(request.Post.Id);

        if (profile == null)
        {
            throw new NotFoundException($"Post with ID {request.Post.Id} not found.");
        }
        
        await _postRepository.UpdateAsync(request.Post);
        return request.Post;
    }
}