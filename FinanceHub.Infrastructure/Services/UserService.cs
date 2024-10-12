using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Servises;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using FinanceHub.Infrastructure.Helpers;

namespace FinanceHub.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User> CreateUserAsync(User user)
    {
        try
        {
            var existingUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existingUser != null)
            {
                throw new ValidationException($"User with email {user.Email} already exists.");
            }

            await _userRepository.AddAsync(user);

            return user;
        }
        catch (RepositoryException ex)
        {
            throw new RepositoryException("There was a problem with the database operation.", ex);
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred while creating the user.", ex);
        }
    }
    
    public async Task<User> GetUserByCredentialsAsync(string userEmail, string password)
    {
        var user = await _userRepository.GetByEmailAsync(userEmail);
        if (user == null)
        {
            return null; 
        }

        var result =  PasswordHasher.VerifyPassword(password, user.PasswordHash);
        if (!result)
        {
            return null; 
        }

        return user;
    }

}