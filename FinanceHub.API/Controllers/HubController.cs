using AutoMapper;
using FinanceGub.Application.DTOs.Hub;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class
    HubController(
        IHubRepository hubRepository,
        IMapper mapper,
        IMediator mediator,
        IHubMemberRepository hubMemberRepository,
        IAzureBlobStorageService azureBlobStorageService,
        IHubJoinRequestRepository
            hubJoinRequestRepository) // use the repo here isnt right 
    : Controller
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetHubDto>>> GetAllHubs()
    {
        var hubs = await hubRepository.GetAllAsync("Posts");
        var hubDtos = mapper.Map<IEnumerable<GetHubDto>>(hubs);

        return Ok(hubDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetHubDto>> GetHubById(Guid id)
    {
        var hub = await hubRepository.GetByIdAsync(id, "Posts");

        var hubDto = mapper.Map<GetHubDto>(hub);

        return Ok(hubDto);
    }
    
    [HttpGet("get-all-hubs-members")]
    public async Task<ActionResult<IEnumerable<HubMember>>> GetAllHubMembers(Guid hubId)
    {
        var members = await hubRepository.GetHubMembersAsync(hubId);
        //var hubDtos = mapper.Map<IEnumerable<GetHubDto>>(hubs);
        
        return Ok(members);
    }
    
    [HttpGet("check-if-user-can-write-posts/{hubId}")]
    public async Task<ActionResult<bool>> CheckIfUserCanWritePost(Guid hubId)
    {
        try
        {
            var email = User.GetEmail();
            var user = await _mediator.Send(new GetByEmailUserQuery(email));
            if (user == null)
                return Unauthorized();
        
            bool canWrite = await hubRepository.CheckIfUserCanWritePostAsync(hubId, user.Id);
            return Ok(canWrite);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error checking write permissions: {ex.Message}");
        }
    }



    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> CreateHub([FromForm] CreateHubDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var email = User.GetEmail();
        var currentUser = await _mediator.Send(new GetByEmailUserQuery(email));
        if (currentUser == null)
            return Unauthorized();

        // Map DTO to Hub entity
        var newHub = mapper.Map<Hub>(dto);

        // Handle file uploads for images
        if (dto.MainPhoto != null)
        {
            newHub.MainPhotoUrl = await azureBlobStorageService.AddMainHubPhotoAsync(dto.MainPhoto);
        }

        if (dto.BackgroundPhoto != null)
        {
            newHub.BackgroundPhotoUrl = await azureBlobStorageService.AddBackHubPhotoAsync(dto.BackgroundPhoto);
        }

        var createdHub = await hubRepository.AddHubAsync(newHub);

        // Add creator as Hub Admin
        var hubMember = new HubMember
        {
            HubId = createdHub.Id,
            UserId = currentUser.Id,
            Role = "Admin",
            IsApproved = true,
            JoinedAt = DateTime.UtcNow
        };

        await hubMemberRepository.AddAsync(hubMember);

        return Ok(new { message = "Hub created successfully", hubId = createdHub.Id });
    }

    [HttpPost("request-join")]
    [Authorize]
    public async Task<IActionResult> RequestJoinHub([FromBody] CreateHubJoinRequestDto createHubJoinRequestDto)
    {
        var currentUser = await _mediator.Send(new GetByEmailUserQuery(User.GetEmail()));
        if (currentUser == null)
            return Unauthorized();

        var isAdmin = await IsUserAdminOfHub(currentUser.Id, createHubJoinRequestDto.HubId);

        if (isAdmin)
        {
            return BadRequest(new { message = "You are the admin!" });
        }
        
        var existingRequests = await hubJoinRequestRepository.GetAllAsync();

        var existingRequest = existingRequests
            .FirstOrDefault(r => r.UserId == currentUser.Id && r.HubId == createHubJoinRequestDto.HubId);

        if (existingRequest != null)
        {
            return BadRequest(new { message = $"You have already requested to join this hub. Your status is {existingRequest.Status}" });
        }

        var request = new HubJoinRequest
        {
            HubId = createHubJoinRequestDto.HubId,
            UserId = currentUser.Id,
            Content = createHubJoinRequestDto.Content,
            Description = createHubJoinRequestDto.Description
        };

        await hubJoinRequestRepository.AddAsync(request);

        return Ok(new { message = "Join request sent successfully." });
    }

    [HttpPut("approve-request/{requestId}")]
    public async Task<IActionResult> ApproveJoinRequest(Guid requestId)
    {
        var request = await hubJoinRequestRepository.GetByIdAsync(requestId);
        if (request == null)
            return NotFound("Request not found.");

        // Ensure only the hub admin can approve
        var hub = await hubRepository.GetByIdAsync(request.HubId);
        var currentUserId = await GetCurrentUserId();
        if (hub == null ||
            !await IsUserAdminOfHub(currentUserId, hub.Id)) // Check if the current user is the admin of the hub
            return Unauthorized();

        // Update the status of the request to 'Approved'
        request.Status = "Approved";
        await hubJoinRequestRepository.UpdateAsync(request);

        // Add the user as a member of the hub
        var hubMember = new HubMember
        {
            HubId = request.HubId,
            UserId = request.UserId,
            Role = "Member", // Assign default role as "Member"
            IsApproved = true,
            JoinedAt = DateTime.UtcNow,
            Description = request.Description
        };

        await hubMemberRepository.AddAsync(hubMember);

        return Ok(new { message = "Request approved and user added to the hub." });
    }

    [HttpPut("deny-request/{requestId}")]
    public async Task<IActionResult> DenyJoinRequest(Guid requestId)
    {
        var request = await hubJoinRequestRepository.GetByIdAsync(requestId);
        if (request == null)
            return NotFound("Request not found.");

        // Ensure only the hub admin can deny
        var hub = await hubRepository.GetByIdAsync(request.HubId);
        var currentUserId = await GetCurrentUserId();
        if (hub == null ||
            !await IsUserAdminOfHub(currentUserId, hub.Id)) // Check if the current user is the admin of the hub
            return Unauthorized();

        // Update the status of the request to 'Denied'
        request.Status = "Denied";
        await hubJoinRequestRepository.UpdateAsync(request);

        return Ok(new { message = "Request denied." });
    }

    private async Task<bool> IsUserAdminOfHub(Guid userId, Guid hubId)
    {
        // Check if the user is an admin of the hub
        var hub = await hubMemberRepository.GetByHubIdToCheckIfAdminAsync(hubId, tracking: false);
        if (hub.UserId == userId) return true;
        return false;
    }

    private async Task<Guid> GetCurrentUserId()
    {
        var email = User.GetEmail();
        var currentUser = await _mediator.Send(new GetByEmailUserQuery(email));
        if (currentUser == null)
            throw new UnauthorizedAccessException("User not found or not authorized.");
    
        return currentUser.Id;
    }

}