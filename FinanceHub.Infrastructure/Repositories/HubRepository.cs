using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;

namespace FinanceHub.Infrastructure.Repositories;

public class HubRepository(FinHubDbContext context) : GenericRepository<Hub>(context), IHubRepository;