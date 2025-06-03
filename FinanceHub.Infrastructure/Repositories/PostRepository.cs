using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinanceGub.Application.DTOs.Post;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class PostRepository(FinHubDbContext context, IMapper mapper) : GenericRepository<Post>(context), IPostRepository
{
    public async Task<int> GetUserPostCount(Guid userId)
    {
        return await _dbSet.CountAsync(f => f.AuthorId == userId);
    }
    
    public IQueryable<Post> GetPostsByUserIds(List<Guid> userIds)
    {
        return _dbSet
            .Where(p => userIds.Contains(p.AuthorId));
    }
    
    public IQueryable<Post> GetPostsByHubIds(List<Guid> hubIds)
    {
        return _dbSet
            .Where(post => post.HubId.HasValue && hubIds.Contains(post.HubId.Value));
    }




}