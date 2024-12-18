namespace FinanceGub.Application.Interfaces.Serviсes;

public interface ILikeService
{
    Task<bool> ToggleLikeAsync(Guid postId, Guid userId);
}