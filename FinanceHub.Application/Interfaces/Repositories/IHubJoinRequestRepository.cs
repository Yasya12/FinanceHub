using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IHubJoinRequestRepository: IGenericRepository<HubJoinRequest>
{
    //Task<HubJoinRequest> GetByHubIdAsync(Guid hubId, string? includeProperties = null, bool tracking = true);
}