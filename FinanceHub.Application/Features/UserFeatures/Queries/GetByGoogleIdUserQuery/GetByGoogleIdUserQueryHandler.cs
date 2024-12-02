using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetByGoogleIdUserQuery;

public class GetByGoogleIdUserQueryHandler : IRequestHandler<GetByGoogleIdUserQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetByGoogleIdUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> Handle(GetByGoogleIdUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByGoogleIdAsync(request.GoogleId);
    }
}