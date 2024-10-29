using AutoMapper;
using FinanceGub.Application.DTOs.Profile;
using FinanceGub.Application.Features.ProfileFeatures.Commands.DeleteProfileCommand;
using FinanceGub.Application.Features.ProfileFeatures.Commands.UpdateProfileCommand;
using FinanceGub.Application.Features.ProfileFeatures.Queries.GetAllProfileQuery;
using FinanceGub.Application.Features.ProfileFeatures.Queries.GetProfileQuery;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Profile = FinanceHub.Core.Entities.Profile;


namespace FinanceHub.Infrastructure.Services;

public class ProfileService : IProfileService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IMediator _mediator;
    private readonly IAzureBlobStorageService _azureBlobStorageService;

    public ProfileService(IMapper mapper, IUserRepository userRepository, IProfileRepository profileRepository, IMediator mediator, IAzureBlobStorageService azureBlobStorageService)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _profileRepository = profileRepository;
        _mediator = mediator;
        _azureBlobStorageService = azureBlobStorageService;
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
    
    public async Task<GetProfileDto> CreateProfileAsync(CreateProfileDto createProfileDto)
    {
        var profile = _mapper.Map<Profile>(createProfileDto);

        var user = await _userRepository.GetByEmailAsync(createProfileDto.UserEmail);
        if (user == null)
        {
            throw new Exception("User with the specified email not found.");
        }

        var existingProfile = await _profileRepository.GetByUserIdAsync(user.Id);
        if (existingProfile != null)
        {
            throw new Exception("A profile with this user email already exists.");
        }
        
        string profilePictureUrl = null;
        if (createProfileDto.ProfilePictureUrl != null)
        {
            try
            {
                profilePictureUrl = await UploadProfilePicture(createProfileDto.ProfilePictureUrl);
            }
            catch (ArgumentException ex)
            {
                throw new Exception($"Failed to upload profile picture: {ex.Message}");
            }
        }


        profile.UserId = user.Id;
        profile.ProfilePictureUrl = profilePictureUrl;
        profile.CreatedAt = DateTime.UtcNow;
        profile.UpdatedAt = DateTime.UtcNow;
        profile.DateOfBirth = DateTime.SpecifyKind(createProfileDto.DateOfBirth, DateTimeKind.Utc);

        await _profileRepository.AddAsync(profile);
        
        var responseProfile = _mapper.Map<GetProfileDto>(profile);
        return responseProfile;
    }
    
    public async Task<Profile> UpdateProfileAsync(Guid id, UpdateProfileDto updateProfileDto)
    {
        var existingProfile = await _profileRepository.GetByIdAsync(id, "User");
        if (existingProfile == null)
        {
            throw new ValidationException($"Profile with ID {id} does not exist.");
        }
        _mapper.Map(updateProfileDto, existingProfile);
        existingProfile.DateOfBirth = DateTime.SpecifyKind(updateProfileDto.DateOfBirth, DateTimeKind.Utc);
        await _mediator.Send(new UpdateProfileCommand(existingProfile));
        
        return existingProfile;
    }
    
    public async Task<string> UploadProfilePicture(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return null;
        }

        var supportedTypes = new[] { "image/jpeg", "image/png" };
        if (!supportedTypes.Contains(file.ContentType))
        {
            throw new ArgumentException("Only JPG and PNG formats are supported.");
        }

        if (file.Length > 2 * 1024 * 1024)
        {
            throw new ArgumentException("File size must be less than 2 MB.");
        }

        try
        {
            var imageUrl = await _azureBlobStorageService.UploadProfilePictureAsync(file);
            return imageUrl;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Internal server error: " + ex.Message);
        }
    }
    
    public async Task<string> DeleteProfileAsync(Guid profileId)
    {
        var profile = await _profileRepository.GetByIdAsync(profileId);
        if (profile == null)
        {
            throw new Exception("Profile not found.");
        }

        await DeleteProfilePicture(profile.ProfilePictureUrl);

        return await _mediator.Send(new DeleteProfileCommand(profileId));
    }

    
    public async Task DeleteProfilePicture(string imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl))
        {
            return; 
        }

        try
        {
            await _azureBlobStorageService.DeleteBlobAsync(imageUrl);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error deleting image from storage: " + ex.Message);
        }
    }

}