using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;

namespace FinanceHub.Infrastructure.Repositories;

public class PostRepository: GenericRepository<Post>, IPostRepository
{
    public PostRepository(FinHubDbContext context) : base(context){ }
}