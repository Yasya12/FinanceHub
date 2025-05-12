using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetUserByCredentialsQuery;

public class GetUserByCredentialsQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUserByCredentialsQuery, User>
{
    public async Task<User> Handle(GetUserByCredentialsQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email);
        if (user == null || !PasswordHasher.VerifyPassword(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid email or password.");
        return user;
    }
}