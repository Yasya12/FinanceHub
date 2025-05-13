using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IHubJoinRequestRepository: IGenericRepository<HubJoinRequest>
{
    Task<HubJoinRequest?> GetRequestByHubAbdUserIdAsync(Guid hubId, Guid userId);

    Task<IEnumerable<HubJoinRequest>> GetAllHubRequestAsync(Guid hubId, string? includeProperties = null);
    //Task<HubJoinRequest> GetByHubIdAsync(Guid hubId, string? includeProperties = null, bool tracking = true);
}