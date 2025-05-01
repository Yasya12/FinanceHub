// using FinanceGub.Application.Features.UserFeatures.Commands.CreateUserCommand;
// using FinanceGub.Application.Interfaces.Repositories;
// using FinanceHub.Core.Exceptions;
// using Moq;
//
// namespace FinanceHub.TestProject.Commands.User;
//
// public class CreateUserCommandTests
// {
//     private readonly Mock<IUserRepository> _mockUserRepository;
//     private readonly CreateUserCommandHandler _handler;
//
//     public CreateUserCommandTests()
//     {
//         _mockUserRepository = new Mock<IUserRepository>();
//         _handler = new CreateUserCommandHandler(_mockUserRepository.Object);
//     }
//     
//     private static readonly Core.Entities.User User = new()
//     {
//         Username = "user",
//         Email = "user@gmail.com",
//         PasswordHash = "validPasswordHash"
//     };
//
//     [Fact]
//     public async Task CreateUser_SuccessfullyCreatesUser_WhenValidDataProvided()
//     {
//         //Arrange
//         var command = new CreateUserCommand(User);
//
//         //Act
//         await _handler.Handle(command, default);
//
//         //Assert
//         _mockUserRepository.Verify(repo => repo.AddAsync(It.IsAny<Core.Entities.User>()), Times.Once);
//     }
//
//     [Fact]
//     public async Task CreateUser_ThrowsException_WhenUserAlreadyExists()
//     {
//         //Arrange
//         var command = new CreateUserCommand(User);
//         
//         // Симулюємо, що користувач уже існує в базі даних.
//         // _mockUserRepository
//         //     .Setup(repo => repo.GetByEmailAsync(It.IsAny<string>()))
//         //     .ReturnsAsync(User);
//         
//         //Act & Assert
//         var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, default));
//         
//         Assert.Equal($"User with email {User.Email} already exists.", exception.Message);
//         _mockUserRepository.Verify(repo => repo.AddAsync(It.IsAny<Core.Entities.User>()), Times.Never);
//     }
// }
