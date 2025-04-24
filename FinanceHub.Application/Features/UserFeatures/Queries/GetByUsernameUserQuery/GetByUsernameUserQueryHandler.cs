using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetByUsernameUserQuery;

public class GetByUsernameUserQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetByUsernameUserQuery, User>
{
    public async Task<User> Handle(GetByUsernameUserQuery request, CancellationToken cancellationToken)
    {
        return await userRepository.GetByUsernameAsync(request.Username);
    }
}