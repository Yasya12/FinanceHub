using FinanceGub.Application.DTOs.Post;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<IEnumerable<Post>> SearchPostsAsync(string query, int takeCount);
    Task<int> GetUserPostCount(Guid userId);
    IQueryable<Post> GetPostsByUserIds(List<Guid> userIds);
    IQueryable<Post> GetPostsByHubIds(List<Guid> hubIds);
}