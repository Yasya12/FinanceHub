using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Commands.UpdateUserCommand;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
{
    private readonly IUserRepository _userRepository;
    
    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UpdateUserCommand userCommand, CancellationToken token)
    {
        var user = await _userRepository.GetByIdAsync(userCommand.User.Id);

        if (user == null)
        {
            throw new NotFoundException($"User with ID {userCommand.User.Id} not found.");
        }
        
        await _userRepository.UpdateAsync(userCommand.User);
        return userCommand.User;
    }
}