using FinanceGub.Application.Features.LikeFeatures.Commands.CreateLikeCommand;
using FinanceGub.Application.Features.LikeFeatures.Commands.DeleteLikeCommand;
using FinanceGub.Application.Features.LikeFeatures.Queries.GetLikesCountQuery;
using FinanceGub.Application.Features.LikeFeatures.Queries.GetSingleLikeQuery;
using FinanceGub.Application.Interfaces;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using MediatR;

public class LikeService : ILikeService
{
    private readonly IMediator _mediator;
    private readonly ILikeHub _likeHub;
    private const int DeleteLike = -1;
    private const int AddLike = 1;

    public LikeService(IMediator mediator, ILikeHub likeHub)
    {
        _mediator = mediator;
        _likeHub = likeHub;
    }

    public async Task<bool> ToggleLikeAsync(Guid postId, Guid userId)
    {
        var existingLike = await _mediator.Send(new GetSingleLikeQuery(postId, userId));

        if (existingLike != null)
        {
            await _mediator.Send(new DeleteLikeCommand(existingLike.Id));

            await UpdateLikeCountAndNotify(postId, DeleteLike);
            return false;
        }
        else
        {
            var newLike = new Like { PostId = postId, UserId = userId };
            await _mediator.Send(new CreateLikeCommand(newLike));

            await UpdateLikeCountAndNotify(postId, AddLike);
            return true;
        }
    }
    
    private async Task UpdateLikeCountAndNotify(Guid postId, int change)
    {
        var currentLikesCount = await _mediator.Send(new GetLikesCountQuery(postId));
        
        var updatedLikesCount = currentLikesCount + change;

        try
        {
            await _likeHub.SendLikeUpdate(postId, updatedLikesCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending like update: {ex.Message}");
        }
    }
}
