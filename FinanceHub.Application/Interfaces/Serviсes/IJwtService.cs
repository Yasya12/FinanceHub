using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IJwtService
{
    string GenerateToken(User user);
}