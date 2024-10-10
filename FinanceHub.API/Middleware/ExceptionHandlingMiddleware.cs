using System.Net;
using System.Text.Json;
using FinanceHub.Core.Exceptions;

namespace FinanceHub.Middleware;

public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred.");

            HttpStatusCode status;
            string message;

            switch (exception)
            {
                case NotFoundException notFoundEx:
                    status = HttpStatusCode.NotFound;
                    message = notFoundEx.Message;
                    break;
                case ValidationException validationEx:
                    status = HttpStatusCode.BadRequest;
                    message = validationEx.Message;
                    break;
                case RepositoryException repoEx:
                    status = HttpStatusCode.InternalServerError;
                    message = repoEx.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = exception.Message; 
                    break;
            }

            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(result);
        }
    }