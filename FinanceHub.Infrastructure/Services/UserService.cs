using AutoMapper;
using FinanceGub.Application.DTOs.User;
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

    public async Task<User> CreateUserAsync(CreateUserDto createUserDto)
    {
        try
        {
            var existingUser = await _userRepository.GetByEmailAsync(createUserDto.Email);
            if (existingUser != null)
            {
                throw new ValidationException($"User with email {createUserDto.Email} already exists.");
            }
            
            var user = _mapper.Map<User>(createUserDto);
            user.Role = FinanceGub.Application.Identity.IdentityData.UserUserClaimName;
            await _userRepository.AddAsync(user);

            var profile = _mapper.Map<Profile>(createUserDto);
            profile.UserId = user.Id;
            profile.DateOfBirth = DateTime.UtcNow;
            
            await _profileRepository.AddAsync(profile);

            return user;
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