using FinanceGub.Application.DTOs.Notification;
using FinanceGub.Application.Features.LikeFeatures.Commands.CreateLikeCommand;
using FinanceGub.Application.Features.LikeFeatures.Commands.DeleteLikeCommand;
using FinanceGub.Application.Features.LikeFeatures.Queries.GetLikesCountQuery;
using FinanceGub.Application.Features.LikeFeatures.Queries.GetSingleLikeQuery;
using FinanceGub.Application.Interfaces;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceHub.Infrastructure.Services;

public class LikeService : ILikeService
{
    private readonly IMediator _mediator;
    private readonly ILikeHub _likeHub;
    private readonly INotificationService _notificationService;
    private readonly IPostService _postService;
    private readonly IUserService _userService;
    private const int DeleteLike = -1;
    private const int AddLike = 1;

    public LikeService(IMediator mediator, ILikeHub likeHub, INotificationService notificationService, IPostService postService, IUserService userService)
    {
        _mediator = mediator;
        _likeHub = likeHub;
        _notificationService = notificationService;
        _postService = postService;
        _userService = userService;
    }

    public async Task<bool> ToggleLikeAsync(Guid postId, Guid userId, string username)
    {
        var existingLike = await _mediator.Send(new GetSingleLikeQuery(postId, userId));
        var post = await _postService.GetPostAsync(postId);
        if (post == null)
            throw new KeyNotFoundException("Post not found.");
        
        var userWhomLiked = await _userService.GetUserByUsernameAsync(post.UserName);
        if (userWhomLiked == null)
            throw new KeyNotFoundException("No such user, that you wanted to liked. Try again later.");
        
        //notification info
        var content = $"{username} liked your post.";
        var notificationDto = new CreateNotificationDto
        {
            UserId = userWhomLiked.Id,
            TriggeredBy = userId,
            Type = "like",
            Content = content,
            PostId = postId
        };
        
        if (existingLike != null)
        {
            await _mediator.Send(new DeleteLikeCommand(existingLike.Id));

            await UpdateLikeCountAndNotify(postId, DeleteLike);
            
            //delete notification
            await _notificationService.RemoveNotificationAsync(notificationDto);
            
            return false;
        }
        else
        {
            var newLike = new Like { PostId = postId, UserId = userId };
            await _mediator.Send(new CreateLikeCommand(newLike));

            await UpdateLikeCountAndNotify(postId, AddLike);
            
            //create notification
            if(username != post.UserName) await _notificationService.CreateNotification(notificationDto);
            
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
    
    public async Task<bool> IsPostLikedAsync(Guid postId, Guid userId)
    {
        var existingLike = await _mediator.Send(new GetSingleLikeQuery(postId, userId));
        return existingLike != null;  
    }
}