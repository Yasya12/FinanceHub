using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;

namespace FinanceHub.Infrastructure.Repositories;

public class PostImageRepository: GenericRepository<PostImage>, IPostImageRepository
{
    public PostImageRepository(FinHubDbContext context) : base(context){ }
}