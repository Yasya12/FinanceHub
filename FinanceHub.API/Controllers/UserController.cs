using FinanceGub.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using FinanceHub.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController
{
    public UserController(IMediator mediator, ILogger<BaseController> logger) : base(mediator, logger)
    {
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
    {
        return await Send(new GetAllUserQuery());
    }
}