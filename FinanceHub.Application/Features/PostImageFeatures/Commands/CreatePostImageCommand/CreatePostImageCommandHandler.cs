using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostImageFeatures.Commands.CreatePostImageCommand;

public class CreatePostImageCommandHandler: IRequestHandler< CreatePostImageCommand, PostImage>
{
    private readonly IPostImageRepository _postImageRepository;

    public CreatePostImageCommandHandler(IPostImageRepository postImageRepository)
    {
        _postImageRepository = postImageRepository;
    }
    
    public async Task<PostImage> Handle(CreatePostImageCommand request, CancellationToken cancellationToken)
    {
        await _postImageRepository.AddAsync(request.PostImage);
        return request.PostImage;
    }
}