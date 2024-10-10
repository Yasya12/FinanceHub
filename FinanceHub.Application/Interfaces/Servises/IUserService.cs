using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Servises;

public interface IUserService
{
    Task<User> CreateUserAsync(User user);
}