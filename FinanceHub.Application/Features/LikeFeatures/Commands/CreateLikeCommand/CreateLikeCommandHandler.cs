using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.LikeFeatures.Commands.CreateLikeCommand;

public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, Like>
{
    private readonly ILikeRepository _likeRepository;

    public CreateLikeCommandHandler(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }
    
    public async Task<Like> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
    {
        await _likeRepository.AddAsync(request.Like);
        return request.Like;
    }
}