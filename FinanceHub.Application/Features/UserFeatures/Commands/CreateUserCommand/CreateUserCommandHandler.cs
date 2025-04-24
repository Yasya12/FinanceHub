using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Commands.CreateUserCommand;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, User>
{
    public async Task<User> Handle(CreateUserCommand userCommand, CancellationToken token)
    {
        var existingUser = await userRepository.GetByEmailAsync(userCommand.user.Email);
        if (existingUser != null)
        {
            throw new ValidationException($"User with email {userCommand.user.Email} already exists.");
        }
        await userRepository.AddAsync(userCommand.user);
        return userCommand.user;
    }
}