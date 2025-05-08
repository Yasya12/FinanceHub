using AutoMapper;
using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Features.UserFeatures.Commands.CreateUserCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByUsernameUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetUserQuery;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using Google.Apis.Auth;
using MediatR;

namespace FinanceHub.Infrastructure.Services;

public class UserService(IMediator mediator, IMapper mapper, IUserRepository userRepository) : IUserService
{
    public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
    {
        var users = await mediator.Send(new GetAllUserQuery());
        
        var userDtos = mapper.Map<IEnumerable<GetUserDto>>(users);

        return userDtos;
    }

    public async Task<GetUserDto> GetUserAsync(Guid id)
    {
        var user = await mediator.Send(new GetUserQuery(id));
        
        var userDto = mapper.Map<GetUserDto>(user);

        return userDto;
    }

    public async Task<GetUserDto> GetUserByEmailAsync(string email)
    {
        var user = await mediator.Send(new GetByEmailUserQuery(email));
        
        if(user == null) throw new Exception($"User with email {email} don`t exists.");
        
        var userDto = mapper.Map<GetUserDto>(user);

        return userDto;
    }
    
    public async Task<GetUserDto> GetUserByUsernameAsync(string username)
    {
        var user = await mediator.Send(new GetByUsernameUserQuery(username));
        
        if(user == null) throw new Exception($"User with username {username} don`t exists.");
        
        var userDto = mapper.Map<GetUserDto>(user);

        return userDto;
    }

    public async Task<CreateUserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        try
        {
            var existingUser = await mediator.Send(new GetByEmailUserQuery(createUserDto.Email));

            if (existingUser != null)
            {
                if (existingUser.Email == createUserDto.Email)
                    throw new ValidationException($"User with email {createUserDto.Email} already exists.");

                if (existingUser.Username?.ToLower() == createUserDto.Username.ToLower())
                    throw new ValidationException($"User with username {createUserDto.Username} already exists.");
            }

            createUserDto.Username = createUserDto.Username.ToLower();

            var user = mapper.Map<User>(createUserDto);
            await mediator.Send(new CreateUserCommand(user));

            return createUserDto;
        }
        catch (RepositoryException ex)
        {
            throw new RepositoryException("Database operation failed.", ex);
        }
        catch (ValidationException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error during user creation.", ex);
        }
    }
    
    public async Task<bool> UpdateUserAsync(string email, UpdateUserDto updateUserDto)
    {
        var user = await mediator.Send(new GetByEmailUserQuery(email));
        if (user == null)
        {
            throw new ValidationException($"User with email {email} does not exist.");
        }
        
        if (user.Username != updateUserDto.Username)
        {
            var existingWithUsername = await mediator.Send(new GetByUsernameUserQuery(updateUserDto.Username));
            if (existingWithUsername != null)
            {
                throw new ValidationException($"Username {updateUserDto.Username} is already taken.");
            }
        }

        //SEE IF I NEED IT
        // if (existingUser.Email != updateUserDto.Email)
        // {
        //     var emailCheckUser = await _mediator.Send(new GetByEmailUserQuery(updateUserDto.Email));
        //     if (emailCheckUser != null)
        //     {
        //         throw new ValidationException($"Email {updateUserDto.Email} is already taken.");
        //     }
        // }

        mapper.Map(updateUserDto, user);
        //if the user send the same data it will be false and return a badrequest
        //await mediator.Send(new UpdateUserCommand(user));
        if (await userRepository.SaveAllAsync()) return true;
        return false;
    }
    
    public async Task<User> CreateUserFromGoogleAsync(GoogleJsonWebSignature.Payload payload)
    {
        var username = $"{payload.GivenName}{payload.FamilyName}"; 
        username = username.ToLower().Replace(" ", ""); 

        if (username.Length > 20)
        {
            username = username.Substring(0, 20); 
        }
        
        var newUser = new User
        {
            GoogleId = payload.Subject,  
            Username = username,   
            Email = payload.Email,       
            Role = "User"   // це вирішити через посилання між шарами             
        };

        await mediator.Send(new CreateUserCommand(newUser));
        return newUser;
    }
}