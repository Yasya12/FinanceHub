using AutoMapper;
using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Features.ProfileFeatures.Commands.UpdateProfileCommand;
using FinanceGub.Application.Features.UserFeatures.Commands.UpdateUserCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetUserQuery;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using FinanceHub.Infrastructure.Helpers;
using MediatR;
using Profile = FinanceHub.Core.Entities.Profile;

namespace FinanceHub.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IProfileRepository profileRepository, IMediator mediator ,IMapper mapper)
    {
        _userRepository = userRepository;
        _profileRepository = profileRepository;
        _mediator = mediator;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();

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
            var existingUser = await _userRepository.GetByEmailAsync(createUserDto.Email);
            if (existingUser != null)
            {
                throw new ValidationException($"User with email {createUserDto.Email} already exists.");
            }
            
            var user = _mapper.Map<User>(createUserDto);
            await _userRepository.AddAsync(user);

            var profile = _mapper.Map<Profile>(createUserDto);
            profile.UserId = user.Id;
            profile.DateOfBirth = DateTime.UtcNow;
            
            await _profileRepository.AddAsync(profile);

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
        var existingUser = await _userRepository.GetByIdAsync(id);
        if (existingUser == null)
        {
            throw new ValidationException($"User with ID {id} does not exist.");
        }

        if (existingUser.Email != updateUserDto.Email)
        {
            var emailCheckUser = await _userRepository.GetByEmailAsync(updateUserDto.Email);
            if (emailCheckUser != null)
            {
                throw new ValidationException($"Email {updateUserDto.Email} is already taken.");
            }
        }

        _mapper.Map(updateUserDto, existingUser);
        await _mediator.Send(new UpdateUserCommand(existingUser));

        var existingProfile = await _profileRepository.GetByUserIdAsync(id);
        if (existingProfile == null)
        {
            throw new ValidationException($"Profile for user with ID {id} does not exist."); 
        }
        
        _mapper.Map(updateUserDto, existingProfile); 
        existingProfile.DateOfBirth = DateTime.UtcNow;
        await _mediator.Send(new UpdateProfileCommand(existingProfile));

        return existingUser;
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