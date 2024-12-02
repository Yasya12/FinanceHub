using AutoMapper;
using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Features.ProfileFeatures.Commands.CreateProfileCommand;
using FinanceGub.Application.Features.ProfileFeatures.Commands.UpdateProfileCommand;
using FinanceGub.Application.Features.ProfileFeatures.Queries.GetByUserIdProfileQuery;
using FinanceGub.Application.Features.UserFeatures.Commands.CreateUserCommand;
using FinanceGub.Application.Features.UserFeatures.Commands.UpdateUserCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByGoogleIdUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetUserQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using FinanceHub.Infrastructure.Helpers;
using Google.Apis.Auth;
using MediatR;
using Profile = FinanceHub.Core.Entities.Profile;

namespace FinanceHub.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserService(IMediator mediator ,IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
    {
        var users = _mediator.Send(new GetAllUserQuery());
        
        var userDtos = _mapper.Map<IEnumerable<GetUserDto>>(users);

        return userDtos;
    }

    public async Task<GetUserDto> GetUserAsync(Guid id)
    {
        var user = await _mediator.Send(new GetUserQuery(id));
        
        var userDto = _mapper.Map<GetUserDto>(user);

        return userDto;
    }

    public async Task<CreateUserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        try
        {
            var existingUser = await _mediator.Send(new GetByEmailUserQuery(createUserDto.Email));
            if (existingUser != null)
            {
                throw new ValidationException($"User with email {createUserDto.Email} already exists.");
            }
            
            var user = _mapper.Map<User>(createUserDto);
            await _mediator.Send(new CreateUserCommand(user));

            var profile = _mapper.Map<Profile>(createUserDto);
            profile.UserId = user.Id;
            profile.DateOfBirth = DateTime.SpecifyKind(createUserDto.DateOfBirth, DateTimeKind.Utc);

            await _mediator.Send(new CreateProfileCommand(profile));
            return createUserDto;
        }
        catch (RepositoryException ex)
        {
            throw new RepositoryException("There was a problem with the database operation.", ex);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    
    public async Task<User> UpdateUserAsync(Guid id, UpdateUserDto updateUserDto)
    {
        var existingUser = await _mediator.Send(new GetUserQuery(id));
        if (existingUser == null)
        {
            throw new ValidationException($"User with ID {id} does not exist.");
        }

        if (existingUser.Email != updateUserDto.Email)
        {
            var emailCheckUser = await _mediator.Send(new GetByEmailUserQuery(updateUserDto.Email));
            if (emailCheckUser != null)
            {
                throw new ValidationException($"Email {updateUserDto.Email} is already taken.");
            }
        }

        _mapper.Map(updateUserDto, existingUser);
        await _mediator.Send(new UpdateUserCommand(existingUser));

        var existingProfile = await _mediator.Send(new GetByUserIdProfileQuery(id));
        if (existingProfile == null)
        {
            throw new ValidationException($"Profile for user with ID {id} does not exist."); 
        }
        
        _mapper.Map(updateUserDto, existingProfile); 
        existingProfile.DateOfBirth = DateTime.SpecifyKind(updateUserDto.DateOfBirth, DateTimeKind.Utc);
        await _mediator.Send(new UpdateProfileCommand(existingProfile));

        return existingUser;
    }
    
    public async Task<User> GetUserByCredentialsAsync(string userEmail, string password)
    {
        var user = await _mediator.Send(new GetByEmailUserQuery(userEmail));
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
    
    public async Task<User> GetUserByGoogleIdAsync(string googleId)
    {
        return await _mediator.Send(new GetByGoogleIdUserQuery(googleId));
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

        await _mediator.Send(new CreateUserCommand(newUser));
        return newUser;
    }
}