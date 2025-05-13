using AutoMapper;
using FinanceGub.Application.DTOs.Hub;
using FinanceGub.Application.DTOs.Notification;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByUsernameUserQuery;
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
            hubJoinRequestRepository,
        INotificationService notificationService) // use the repo here isnt right 
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

    [HttpGet("get-all-hubs-requests/{hubId}")]
    public async Task<ActionResult<IEnumerable<GetHubJoinRequestDto>>> GetAllHubRequest(Guid hubId)
    {
        var requests = await hubJoinRequestRepository.GetAllHubRequestAsync(hubId,"Hub,User");

        var requestsDto = mapper.Map<IEnumerable<GetHubJoinRequestDto>>(requests);

        return Ok(requestsDto);
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

    [HttpGet("is-admin/{hubId}")]
    public async Task<ActionResult<bool>> IsAdmin(Guid hubId)
    {
        try
        {
            var email = User.GetEmail();
            var user = await _mediator.Send(new GetByEmailUserQuery(email));
            if (user == null)
                return Unauthorized();

            bool isAdmin = await hubRepository.IsAdmin(hubId, user.Id);
            return Ok(isAdmin);
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

        // Check if a hub with the same name already exists
        var existingHub = await hubRepository.GetHubByNameAsync(dto.Name);
        if (existingHub != null)
        {
            return BadRequest(new { message = "A hub with this name already exists." });
        }

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

    [HttpPut("update/{id:guid}")]
    [Authorize]
    public async Task<IActionResult> UpdateHub(Guid id, [FromForm] UpdateHubDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var email = User.GetEmail();
        var currentUser = await _mediator.Send(new GetByEmailUserQuery(email));
        if (currentUser == null)
            return Unauthorized();

        var hub = await hubRepository.GetByIdAsync(id);
        if (hub == null)
            return NotFound(new { message = "Hub not found." });

        // Check if the user is an admin of the hub
        if (!await IsUserAdminOfHub(currentUser.Id, hub.Id))
            return Forbid("You do not have permission to update this hub.");

        // Update the hub details
        hub.Name = dto.Name ?? hub.Name;
        hub.Description = dto.Description ?? hub.Description;

        // Handle file uploads for images
        if (dto.MainPhoto != null)
        {
            if (hub.MainPhotoUrl != null) await azureBlobStorageService.DeletePhotoAsync(hub.MainPhotoUrl);
            hub.MainPhotoUrl = await azureBlobStorageService.AddMainHubPhotoAsync(dto.MainPhoto);
        }

        if (dto.BackgroundPhoto != null)
        {
            if (hub.BackgroundPhotoUrl != null) await azureBlobStorageService.DeletePhotoAsync(hub.BackgroundPhotoUrl);
            hub.BackgroundPhotoUrl = await azureBlobStorageService.AddBackHubPhotoAsync(dto.BackgroundPhoto);
        }

        await hubRepository.UpdateAsync(hub);

        return Ok(new { message = "Hub updated successfully" });
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
            return BadRequest(new
                { message = $"You have already requested to join this hub. Your status is {existingRequest.Status}" });
        }

        var request = new HubJoinRequest
        {
            HubId = createHubJoinRequestDto.HubId,
            UserId = currentUser.Id,
            Content = createHubJoinRequestDto.Content,
            Description = createHubJoinRequestDto.Description
        };

        await hubJoinRequestRepository.AddAsync(request);

        // Створення нотифікації для адміністратора хабу
        var hubMember =
            await hubMemberRepository.GetByHubIdToCheckIfAdminAsync(createHubJoinRequestDto.HubId, tracking: false);
        var hub = await hubRepository.GetByIdAsync(createHubJoinRequestDto.HubId);
        var createdRequest =
            await hubJoinRequestRepository.GetRequestByHubAbdUserIdAsync(createHubJoinRequestDto.HubId, currentUser.Id);
        var content = $"{currentUser.UserName} requested to join your hub {hub.Name}.";

        var notificationDto = new CreateNotificationDto
        {
            UserId = hubMember.UserId,
            TriggeredBy = currentUser.Id,
            Type = "request",
            Content = content,
            HubId = createHubJoinRequestDto.HubId,
            RequestId = createdRequest.Id
        };

        await notificationService.CreateNotification(notificationDto);

        return Ok(new { message = "Join request sent successfully." });
    }

    [HttpPut("approve-request/{requestId}")]
    [Authorize]
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
        
        // Створення нотифікації про прийняття
        var email = User.GetEmail();
        var currentUser = await _mediator.Send(new GetByEmailUserQuery(email));
        var content = $"{currentUser.UserName} approved your requested to join the hub {hub.Name}.";

        var notificationDto = new CreateNotificationDto
        {
            UserId = hubMember.UserId,
            TriggeredBy = currentUser.Id,
            Type = "request",
            Content = content,
            HubId = hub.Id,
            RequestId = request.Id
        };

        await notificationService.CreateNotification(notificationDto);

        return Ok(new { message = "Request approved and user added to the hub." });
    }

    [HttpPut("deny-request/{requestId}")]
    [Authorize]
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
        
        // Створення нотифікації про прийняття
        var email = User.GetEmail();
        var currentUser = await _mediator.Send(new GetByEmailUserQuery(email));
        var content = $"{currentUser.UserName} denied your requested to join the hub {hub.Name}.";

        var notificationDto = new CreateNotificationDto
        {
            UserId = request.UserId,
            TriggeredBy = currentUser.Id,
            Type = "request",
            Content = content,
            HubId = hub.Id,
            RequestId = request.Id
        };

        await notificationService.CreateNotification(notificationDto);

        return Ok(new { message = "Request denied." });
    }

    private async Task<bool> IsUserAdminOfHub(Guid userId, Guid hubId)
    {
        // Check if the user is an admin of the hub
        var hubMember = await hubMemberRepository.GetByHubIdToCheckIfAdminAsync(hubId, tracking: false);
        if (hubMember == null) return false;
        if (hubMember.UserId == userId) return true;
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
    
    [HttpDelete("delete-member/{hubId}/{username}")]
    [Authorize]
    public async Task<IActionResult> DeleteHubMember(Guid hubId, string username)
    {
        try
        {
            var currentUserId = await GetCurrentUserId();

            // Перевірка, чи користувач є адміністратором хабу
            if (!await IsUserAdminOfHub(currentUserId, hubId))
                return Forbid("You do not have permission to delete this member.");

            var user = await mediator.Send(new GetByUsernameUserQuery(username));

            var hubMember = await hubMemberRepository.GetByHubIdAndUserIdAsync(hubId, user.Id);
            if (hubMember == null)
                return NotFound(new { message = "Hub member not found." });

            await hubMemberRepository.DeleteAsync(hubMember.Id);
            
            //change status of the request
            var request = await hubJoinRequestRepository.GetRequestByHubAbdUserIdAsync(hubId, user.Id);
            request.Status = "Deleted User";
            await hubJoinRequestRepository.UpdateAsync(request);
            
            // Створення нотифікації про прийняття
            var hub = await hubRepository.GetByIdAsync(hubId);
            
            var email = User.GetEmail();
            var currentUser = await _mediator.Send(new GetByEmailUserQuery(email));
            var content = $"{currentUser.UserName} deleted you from the hub {hub.Name}.";

            var notificationDto = new CreateNotificationDto
            {
                UserId = hubMember.UserId,
                TriggeredBy = currentUser.Id,
                Type = "request",
                Content = content,
                HubId = hub.Id
            };

            await notificationService.CreateNotification(notificationDto);

            return Ok(new { message = "Hub member deleted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error deleting hub member: {ex.Message}");
        }
    }

}