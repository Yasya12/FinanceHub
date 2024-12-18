namespace FinanceGub.Application.Interfaces;

public interface ILikeHub
{
    Task SendLikeUpdate(Guid postId, int likesCount);
}