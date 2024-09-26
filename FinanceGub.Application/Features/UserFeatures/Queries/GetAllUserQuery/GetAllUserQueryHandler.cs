using FinanceGub.Application.Interfaces.Repositories;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery.GetAllUserQuery, IEnumerable<FinanceHub.Core.Entities.User>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<FinanceHub.Core.Entities.User>> Handle(GetAllUserQuery.GetAllUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(request.IncludeProperties);
    }
}