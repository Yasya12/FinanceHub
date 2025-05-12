using AutoMapper;
using FinanceGub.Application.DTOs.Authentication;
using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Features.TokenFeatures.Commands.GenerateTokenCommand;
using FinanceGub.Application.Features.UserFeatures.Commands.CreateUserFromGoogleCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByGoogleIdUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetUserByCredentialsQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Exceptions;
using Google.Apis.Auth;
using MediatR;

namespace FinanceHub.Infrastructure.Services;

public class AuthService(IMediator mediator, IMapper mapper, IUserService userService)
    : IAuthService
{
    public async Task<(GetUserDto user, string token)> SignupAsync(SignupDto signupDto)
    {
        try
        {
            var createUserDto = mapper.Map<CreateUserDto>(signupDto);
            var returnUserDto = await userService.CreateUserAsync(createUserDto);
            return await LoginAsync(returnUserDto.Email, signupDto.Password);
        }
        catch (ValidationException ex)
        {
            throw new ValidationException($"Signup failed: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error during signup.", ex);
        }
    }


    public async Task<(GetUserDto user, string token)> LoginAsync(string email, string password)
    {
        try
        {
            var user = await mediator.Send(new GetUserByCredentialsQuery(email, password));
            var token = await mediator.Send(new GenerateTokenCommand(user));

            var userDto = mapper.Map<GetUserDto>(user);

            return (userDto, token);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new UnauthorizedAccessException("Invalid email or password.", ex);
        }
    }

    public async Task<(GetUserDto user, string token)> GoogleLoginAsync(string googleToken)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(googleToken);
        var user = await mediator.Send(new GetByGoogleIdUserQuery(payload.Subject))
                   ?? await mediator.Send(new CreateUserFromGoogleCommand(payload));
        
        var token = await mediator.Send(new GenerateTokenCommand(user));
        var userDto = mapper.Map<GetUserDto>(user);

        return (userDto, token);
    }
}