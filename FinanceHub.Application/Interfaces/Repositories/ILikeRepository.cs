using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface ILikeRepository : IGenericRepository<Like>
{
    Task<int> GetLikesCountAsync(Guid postId);
    Task<Like> GetLikeByPostAndUserAsync(Guid postId, Guid userId);
}
