using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Commands.DeleteUserCommand;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    
    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(DeleteUserCommand userCommand, CancellationToken token)
    {
        var user = await _userRepository.GetByIdAsync(userCommand.Id);

        if (user == null)
        {
            throw new NotFoundException($"User with ID {userCommand.Id} not found.");
        }

        var message = await _userRepository.DeleteAsync(userCommand.Id);
        
        return message; 
    }
}