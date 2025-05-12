using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class HubMemberRepository(FinHubDbContext context) : GenericRepository<HubMember>(context), IHubMemberRepository
{
    public async Task<HubMember> GetByHubIdToCheckIfAdminAsync(Guid hubId, string? includeProperties = null, bool tracking = true)
    {
        try
        {
            var query = _dbSet.AsQueryable();

            // Apply AsNoTracking if tracking is disabled
            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            return await query.FirstOrDefaultAsync(u => u.HubId == hubId && u.Role == "Admin");
        }
        catch (RepositoryException ex)
        {
            throw new RepositoryException("An error occurred while trying to retrieve the user by email.", ex);
        }
    }
}