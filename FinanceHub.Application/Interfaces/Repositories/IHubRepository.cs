using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IHubRepository : IGenericRepository<Hub>
{
    Task<Hub> AddHubAsync(Hub entity);
    Task<IEnumerable<dynamic>> GetHubMembersAsync(Guid hubId);
    Task<bool> CheckIfUserCanWritePostAsync(Guid hubId, Guid userId);
}