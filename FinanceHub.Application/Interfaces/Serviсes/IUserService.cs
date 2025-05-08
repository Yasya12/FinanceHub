using FinanceGub.Application.DTOs.User;
using FinanceHub.Core.Entities;
using Google.Apis.Auth;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IUserService
{
    Task<IEnumerable<GetUserDto>> GetAllUsersAsync();
    Task<GetUserDto> GetUserAsync(Guid id);
    Task<GetUserDto> GetUserByEmailAsync(string email);
    Task<GetUserDto> GetUserByUsernameAsync(string username);
    Task<CreateUserDto> CreateUserAsync(CreateUserDto createUserDto);
    Task<bool> UpdateUserAsync(string email, UpdateUserDto updateUserDto);
    Task<User> CreateUserFromGoogleAsync(GoogleJsonWebSignature.Payload payload);
}