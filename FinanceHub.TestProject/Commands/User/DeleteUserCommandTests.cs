using FinanceGub.Application.Features.UserFeatures.Commands.DeleteUserCommand;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Exceptions;
using Moq;

namespace FinanceHub.TestProject.Commands.User;

public class DeleteUserCommandTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly DeleteUserCommandHandler _handler;

    public DeleteUserCommandTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _handler = new DeleteUserCommandHandler(_mockUserRepository.Object);
    }
    
    private static readonly Core.Entities.User User = new()
    {
        Id = Guid.NewGuid(),
        Username = "user",
        Email = "user@gmail.com",
        PasswordHash = "validPasswordHash"
    };
    
    [Fact]
    public async Task DeleteUser_SuccessfullyDeletesUser_WhenUserExists()
    {
        //Arrange
        var command = new DeleteUserCommand(User.Id);

        _mockUserRepository
            .Setup(repo => repo.GetByIdAsync(User.Id, It.IsAny<string>()))
            .ReturnsAsync(User);
        
        //Act
        await _handler.Handle(command, default);

        //Assert 
        _mockUserRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Guid>()), Times.Once);

    }

    [Fact]
    public async Task DeleteUser_ThrowsNotFoundException_WhenUserDoesNotExist()
    {
        //Arrange
        var command = new DeleteUserCommand(User.Id);

        _mockUserRepository
            .Setup(repo => repo.GetByIdAsync(User.Id, It.IsAny<string>()))
            .ReturnsAsync((Core.Entities.User)null!);
        
        //Act & Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, default));
        
        Assert.Equal($"User with ID {User.Id} not found.", exception.Message);
        _mockUserRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Guid>()), Times.Never);
    }

}