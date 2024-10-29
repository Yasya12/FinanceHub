using FinanceGub.Application.DTOs.Profile;
using FinanceGub.Application.Interfaces.Serviсes;
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
    public async Task<ActionResult<IEnumerable<GetProfileDto>>> GetAllProfile()
    {
        var profileDto = await _profileService.GetAllProfileAsync();
        return Ok(profileDto); 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetProfileDto>> GetProfile(Guid id)
    {
        var profileDto = await _profileService.GetProfileAsync(id);
        return Ok(profileDto); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileDto profileDto)
    {
        var profile = await _profileService.CreateProfileAsync(profileDto);
        return Created(string.Empty, profile);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProfile(Guid id, UpdateProfileDto updateProfileDto)
    {
        var updateProfile = await _profileService.UpdateProfileAsync(id, updateProfileDto);
        return Ok(updateProfile);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProfile(Guid id)
    {
        var message = await _profileService.DeleteProfileAsync(id);
        return Content(message); 
    }
  
}