using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetUserByCredentialsQuery;

public class GetUserByCredentialsQueryHandler : IRequestHandler<GetUserByCredentialsQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByCredentialsQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByCredentialsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, "Profile");
        if (user == null || !PasswordHasher.VerifyPassword(request.Password, user.PasswordHash))
            return null;

        return user;
    }
}