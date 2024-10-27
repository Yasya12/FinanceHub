using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IProfileRepository : IGenericRepository<Profile>
{
    Task<Profile> GetByUserIdAsync(Guid userId);
}