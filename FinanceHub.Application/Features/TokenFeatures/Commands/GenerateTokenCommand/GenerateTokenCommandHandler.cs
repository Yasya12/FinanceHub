using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;

namespace FinanceGub.Application.Features.TokenFeatures.Commands.GenerateTokenCommand;

public class GenerateTokenCommandHandler(IJwtService jwtService) : IRequestHandler<GenerateTokenCommand, string>
{
    public async Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var token = await jwtService.GenerateToken(request.User);
        return await Task.FromResult(token);
    }
}