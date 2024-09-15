using FinanceHub.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Data;

public class FinHubDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public FinHubDbContext(DbContextOptions<FinHubDbContext> options):base(options) {}
}