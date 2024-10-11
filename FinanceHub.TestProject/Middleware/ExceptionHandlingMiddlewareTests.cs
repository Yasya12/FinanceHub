using FinanceHub.Core.Exceptions;
using FinanceHub.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace FinanceHub.TestProject.Middleware;

public class ExceptionHandlingMiddlewareTests
{
     [Fact]
    public async Task Middleware_ShouldReturn500_WhenUnhandledExceptionOccurs()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<ExceptionHandlingMiddleware>>();
        
        var context = new DefaultHttpContext();
        RequestDelegate next = (ctx) => throw new Exception("Test Exception");  
        var middleware = new ExceptionHandlingMiddleware(next, mockLogger.Object);

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        Assert.Equal(500, context.Response.StatusCode);  
    }

    [Fact]
    public async Task Middleware_ShouldReturn404_WhenNotFoundExceptionOccurs()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<ExceptionHandlingMiddleware>>();
        
        var context = new DefaultHttpContext();
        RequestDelegate next = (ctx) => throw new NotFoundException("Resource not found"); 
        var middleware = new ExceptionHandlingMiddleware(next, mockLogger.Object);

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        Assert.Equal(404, context.Response.StatusCode); 
    }

    [Fact]
    public async Task Middleware_ShouldReturnBadRequest400_WhenValidationExceptionOccurs()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<ExceptionHandlingMiddleware>>();
        
        var context = new DefaultHttpContext();
        RequestDelegate next = (ctx) => throw new ValidationException("Validation failed"); 
        var middleware = new ExceptionHandlingMiddleware(next, mockLogger.Object);

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        Assert.Equal(400, context.Response.StatusCode);  
    }
}