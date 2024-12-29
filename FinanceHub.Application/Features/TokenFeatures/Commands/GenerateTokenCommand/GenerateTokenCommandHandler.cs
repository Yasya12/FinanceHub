using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;

namespace FinanceGub.Application.Features.TokenFeatures.Commands.GenerateTokenCommand;

public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, string>
{
    private readonly IJwtService _jwtService;

    public GenerateTokenCommandHandler(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var token = _jwtService.GenerateToken(request.User);
        return Task.FromResult(token);
    }
}