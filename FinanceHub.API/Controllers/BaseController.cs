using FinanceHub.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController: Controller 
{
    private readonly IMediator _mediator;
    private readonly ILogger _logger;

    public BaseController(IMediator mediator, ILogger<BaseController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    public async Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
    {
        try
        {
            _logger.LogInformation("Sending request: {Request}", request);
            return Ok(await _mediator.Send(request));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending request: {Request}", request);
            return StatusCode(500, "An error occurred.");
        }
    }
}