using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IHubMemberRepository: IGenericRepository<HubMember>
{
    Task<HubMember> GetByHubIdToCheckIfAdminAsync(Guid hubId, string? includeProperties = null, bool tracking = true);
}