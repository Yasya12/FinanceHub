using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;

public class GetByEmailUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetByEmailUserQuery, User>
{
    public async Task<User> Handle(GetByEmailUserQuery request, CancellationToken cancellationToken)
    {
        return await userRepository.GetByEmailAsync(request.Email);
    }
}