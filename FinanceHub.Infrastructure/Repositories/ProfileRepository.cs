using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;

namespace FinanceHub.Infrastructure.Repositories;

public class ProfileRepository: GenericRepository<Profile>, IProfileRepository
{
    public ProfileRepository(FinHubDbContext context) : base(context) { }
}