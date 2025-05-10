using AutoMapper;
using FinanceGub.Application.DTOs.Hub;
using FinanceGub.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HubController(IHubRepository hubRepository, IMapper mapper) // use the repo here isnt right 
    : Controller
{
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
        var hub = await hubRepository.GetByIdAsync(id,"Posts");

        var hubDto = mapper.Map<GetHubDto>(hub);
        
        return Ok(hubDto); 
    }
}