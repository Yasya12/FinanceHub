using AutoMapper;
using FinanceGub.Application.DTOs.Profile;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using Profile = FinanceHub.Core.Entities.Profile;

namespace FinanceHub.Infrastructure.Services;

public class ProfileService : IProfileService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IMapper mapper, IUserRepository userRepository, IProfileRepository profileRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _profileRepository = profileRepository;
    }
    
    public async Task<Profile> CreateProfileAsync(CreateProfileDto createProfileDto)
    {
        var profile = _mapper.Map<Profile>(createProfileDto);
        
        var user = await _userRepository.GetByEmailAsync(createProfileDto.UserEmail);
        if (user == null)
        {
            throw new Exception("User with the specified email not found.");
        }
        
        profile.UserId = user.Id;
        profile.CreatedAt = DateTime.UtcNow;
        profile.UpdatedAt = DateTime.UtcNow;
        profile.DateOfBirth = DateTime.UtcNow;
        
        await _profileRepository.AddAsync(profile);
        return profile;
    }
}