using AutoMapper;
using FinanceGub.Application.DTOs.Profile;
using FinanceGub.Application.Features.ProfileFeatures.Queries.GetAllProfileQuery;
using FinanceGub.Application.Features.ProfileFeatures.Queries.GetProfileQuery;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;
using Profile = FinanceHub.Core.Entities.Profile;

namespace FinanceHub.Infrastructure.Services;

public class ProfileService : IProfileService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IMediator _mediator;

    public ProfileService(IMapper mapper, IUserRepository userRepository, IProfileRepository profileRepository, IMediator mediator)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _profileRepository = profileRepository;
        _mediator = mediator;
    }
    
    public async Task<IEnumerable<GetProfileDto>> GetAllProfileAsync()
    {
        var profiles = await _mediator.Send(new GetAllProfileQuery("User"));

        var profileDtos = _mapper.Map<IEnumerable<GetProfileDto>>(profiles);

        return profileDtos;
    }
    
    public async Task<GetProfileDto> GetProfileAsync(Guid id)
    {
        var profile = await _mediator.Send(new GetProfileQuery(id, "User"));
        
        var profileDto = _mapper.Map<GetProfileDto>(profile);

        return profileDto;
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