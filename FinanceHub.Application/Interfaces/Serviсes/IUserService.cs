using FinanceGub.Application.DTOs.User;
using FinanceHub.Core.Entities;
using Google.Apis.Auth;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IUserService
{
    Task<IEnumerable<GetUserDto>> GetAllUsersAsync();
    Task<GetUserDto> GetUserAsync(Guid id);
    Task<CreateUserDto> CreateUserAsync(CreateUserDto createUserDto);
    Task<User> UpdateUserAsync(Guid id, UpdateUserDto updateUserDto);
    Task<User> GetUserByCredentialsAsync(string userName, string password);
    Task<User> GetUserByGoogleIdAsync(string googleId);
    Task<User> CreateUserFromGoogleAsync(GoogleJsonWebSignature.Payload payload);
}