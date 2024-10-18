using FinanceGub.Application.DTOs.Profile;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IUserService
{
    Task<User> CreateUserAsync(CreateUserDto createUserDto);
    Task<User> GetUserByCredentialsAsync(string userName, string password);
}