using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class LikeRepository: GenericRepository<Like>, ILikeRepository
{
    public LikeRepository(FinHubDbContext context) : base(context){ }
    
    public async Task<int> GetLikesCountAsync(Guid postId)
    {
        return await _dbSet.CountAsync(like => like.PostId == postId);
    }
    
    public async Task<Like> GetLikeByPostAndUserAsync(Guid postId, Guid userId)
    {
        return await _dbSet.FirstOrDefaultAsync(like => like.PostId == postId && like.UserId == userId);
    }
}