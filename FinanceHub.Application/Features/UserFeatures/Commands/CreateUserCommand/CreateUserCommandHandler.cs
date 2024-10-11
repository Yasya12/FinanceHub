using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Commands.CreateUserCommand;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _userRepository;
    
    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(CreateUserCommand userCommand, CancellationToken token)
    {
        var existingUser = await _userRepository.GetByEmailAsync(userCommand.user.Email);
        if (existingUser != null)
        {
            throw new ValidationException($"User with email {userCommand.user.Email} already exists.");
        }
        await _userRepository.AddAsync(userCommand.user);
        return userCommand.user;
    }
}