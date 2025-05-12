using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IJwtService
{
    Task<string> GenerateToken(User user);
}