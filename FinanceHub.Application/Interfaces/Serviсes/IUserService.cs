using FinanceGub.Application.DTOs.User;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IUserService
{
    Task<IEnumerable<GetUserDto>> GetAllUsersAsync();
    Task<User> CreateUserAsync(CreateUserDto createUserDto);
    Task<User> GetUserByCredentialsAsync(string userName, string password);
}