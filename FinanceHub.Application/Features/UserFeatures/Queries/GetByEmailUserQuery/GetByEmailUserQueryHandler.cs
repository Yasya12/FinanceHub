using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;

public class GetByEmailUserQueryHandler : IRequestHandler<GetByEmailUserQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetByEmailUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User> Handle(GetByEmailUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByEmailAsync(request.Email);
    }
}