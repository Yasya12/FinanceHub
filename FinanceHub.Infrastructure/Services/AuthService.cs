using AutoMapper;
using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Features.TokenFeatures.Commands.GenerateTokenCommand;
using FinanceGub.Application.Features.UserFeatures.Commands.CreateUserFromGoogleCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByGoogleIdUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetUserByCredentialsQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using Google.Apis.Auth;
using MediatR;

namespace FinanceHub.Infrastructure.Services;

public class AuthService: IAuthService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthService(IMediator mediator ,IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<(GetUserDto user, string token)> LoginAsync(string email, string password)
    {
        var user = await _mediator.Send(new GetUserByCredentialsQuery(email, password));
        if (user == null) throw new UnauthorizedAccessException("Invalid credentials");

        var token = await _mediator.Send(new GenerateTokenCommand(user));
        
        var userDto = _mapper.Map<GetUserDto>(user);

        return (userDto, token);
    }

    public async Task<string> GoogleLoginAsync(string googleToken)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(googleToken);
        var user = await _mediator.Send(new GetByGoogleIdUserQuery(payload.Subject))
                   ?? await _mediator.Send(new CreateUserFromGoogleCommand(payload));

        return await _mediator.Send(new GenerateTokenCommand(user));
    }
}