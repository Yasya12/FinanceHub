using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.LikeFeatures.Commands.DeleteLikeCommand;

public class DeleteLikeCommandHandler: IRequestHandler<DeleteLikeCommand, string>
{
    private readonly ILikeRepository _likeRepository;

    public DeleteLikeCommandHandler(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public async Task<string> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
    {
        var comment = await _likeRepository.GetByIdAsync(request.Id);

        if (comment == null)
        {
            throw new NotFoundException($"Like with ID {request.Id} not found.");
        }
        
        var message = await _likeRepository.DeleteAsync(request.Id);
        return message;
    }
}