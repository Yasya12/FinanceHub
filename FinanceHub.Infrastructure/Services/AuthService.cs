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

public class AuthService: IAuthService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public AuthService(IMediator mediator ,IMapper mapper, IUserService userService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _userService = userService;
    }
    
    public async Task<(GetUserDto user, string token)> SignupAsync(SignupDto signupDto)
    {
        try
        {
            var createUserDto = _mapper.Map<CreateUserDto>(signupDto);
            var returnUserDto = await _userService.CreateUserAsync(createUserDto);
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
        var user = await _mediator.Send(new GetUserByCredentialsQuery(email, password));
        if (user == null) throw new UnauthorizedAccessException("Invalid credentials");

        var token = await _mediator.Send(new GenerateTokenCommand(user));
        
        var userDto = _mapper.Map<GetUserDto>(user);

        return (userDto, token);
    }

    public async Task<(GetUserDto user, string token)> GoogleLoginAsync(string googleToken)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(googleToken);
        var user = await _mediator.Send(new GetByGoogleIdUserQuery(payload.Subject))
                   ?? await _mediator.Send(new CreateUserFromGoogleCommand(payload));
        
        var token = await _mediator.Send(new GenerateTokenCommand(user));
        var userDto = _mapper.Map<GetUserDto>(user);

        return (userDto, token);
    }
}