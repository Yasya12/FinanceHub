using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetByUsernameUserQuery;

public class GetByUsernameUserQueryHandler: IRequestHandler<GetByUsernameUserQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetByUsernameUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User> Handle(GetByUsernameUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);

        if (user == null)
        {
            throw new NotFoundException($"User with username '{request.Username}' was not found.");
        }

        return user;
    }
}