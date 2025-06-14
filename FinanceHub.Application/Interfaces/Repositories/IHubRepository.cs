using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IHubRepository : IGenericRepository<Hub>
{
    Task<IEnumerable<Hub>> SearchHubsAsync(string query, int takeCount);
    Task<Hub?> GetHubByNameAsync(string name);
    Task<Hub> AddHubAsync(Hub entity);
    Task<IEnumerable<dynamic>> GetHubMembersAsync(Guid hubId);
    Task<bool> CheckIfUserCanWritePostAsync(Guid hubId, Guid userId);
    Task<bool> IsAdmin(Guid hubId, Guid userId);
    Task<HubMember> GetByHubIdAdminAsync(Guid hubId);
}