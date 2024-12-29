using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Commands.CreateUserFromGoogleCommand;

public class CreateUserFromGoogleCommandHandler: IRequestHandler<CreateUserFromGoogleCommand, User>
{
    private readonly IUserService _userService;

    public CreateUserFromGoogleCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<User> Handle(CreateUserFromGoogleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateUserFromGoogleAsync(request.Payload);
        return user;
    }
}
