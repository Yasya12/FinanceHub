using FinanceGub.Application.DTOs.Profile;
using FinanceGub.Application.Features.ProfileFeatures.Commands.DeleteProfileCommand;
using FinanceGub.Application.Features.ProfileFeatures.Commands.UpdateProfileCommand;
using FinanceGub.Application.Features.ProfileFeatures.Queries.GetAllProfileQuery;
using FinanceGub.Application.Features.ProfileFeatures.Queries.GetProfileQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : BaseController
{
    private readonly IProfileService _profileService;
    public ProfileController(IMediator mediator, ILogger<BaseController> logger, IProfileService profileService): base(mediator, logger)
    {
        _profileService = profileService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Profile>>> GetAllProfile()
    {
        return Ok(await Send(new GetAllProfileQuery("User"))); 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Profile>> GetProfile(Guid id)
    {
        return Ok(await Send(new GetProfileQuery(id, "User")));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileDto profileDto)
    {
        var profile = await _profileService.CreateProfileAsync(profileDto);
        return CreatedAtAction(nameof(CreateProfile), new { id = profile.Id }, profile);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProfile(Guid id, Profile profile)
    {
        if (id != profile.Id)
        {
            return BadRequest("User ID mismatch.");
        }
    
        return Ok(await Send(new UpdateProfileCommand(profile)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProfile(Guid id)
    {
        await Send(new DeleteProfileCommand(id));
        return NoContent();
    }
    
    [HttpPost("upload-profile-picture")]
    public async Task<IActionResult> UploadProfilePicture(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File cannot be empty.");
        }

        var supportedTypes = new[] { "image/jpeg", "image/png" };
        if (!supportedTypes.Contains(file.ContentType))
        {
            return BadRequest("Only JPG and PNG formats are supported.");
        }

        if (file.Length > 2 * 1024 * 1024)
        {
            return BadRequest("File size must be less than 2 MB.");
        }

        try
        {
            //var imageUrl = await _azureBlobStorageService.UploadProfilePictureAsync(file);
            // return Ok(new { imageUrl });
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}