using FinanceGub.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace FinanceHub.Infrastructure.SignalR;

public class LikeHub : Hub, ILikeHub
{
    public async Task SendLikeUpdate(Guid postId, int likesCount)
    {
        await Clients.All.SendAsync("ReceiveLikeUpdate", postId, likesCount);
    }
}