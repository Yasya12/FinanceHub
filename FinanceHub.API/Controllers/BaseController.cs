    using FinanceHub.Core.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    namespace FinanceHub.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class BaseController: Controller 
    {
        private readonly IMediator _mediator;
        protected readonly ILogger Logger;

        public BaseController(IMediator mediator, ILogger<BaseController> logger)
        {
            _mediator = mediator;
            Logger = logger;
        }
        
        public async Task<TResult> Send<TResult>(IRequest<TResult> request)
        {
            try
            {
                Logger.LogInformation("Sending request: {Request}", request);
                var result = await _mediator.Send(request);

                return result != null ?  result : throw new Exception($"No data found for request: {request}");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error sending request: {Request}", request);
                throw;
            }
        }
    }