using FinanceGub.Application.DTOs.Post;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Commands.CreatePostCommand;

public class CreatePostCommandHandler : IRequestHandler< CreatePostCommand, Post>
{
    private readonly IPostRepository _postRepository;

    public CreatePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        await _postRepository.AddAsync(request.Post);
        return request.Post;
    }
}