// using FinanceGub.Application.Features.UserFeatures.Commands.UpdateUserCommand;
// using FinanceGub.Application.Interfaces.Repositories;
// using FinanceHub.Core.Exceptions;
// using Moq;
//
// namespace FinanceHub.TestProject.Commands.User;
//
// public class UpdateUserCommandTests
// {
//     private readonly Mock<IUserRepository> _mockRepository;
//     private readonly UpdateUserCommandHandler _handler;
//
//     public UpdateUserCommandTests()
//     {
//         _mockRepository = new Mock<IUserRepository>();
//         _handler = new UpdateUserCommandHandler(_mockRepository.Object);
//     }
//     
//     private static readonly Core.Entities.User User = new()
//     {
//         Id = Guid.NewGuid(),
//         Username = "user",
//         Email = "user@gmail.com",
//         PasswordHash = "validPasswordHash"
//     };
//     
//     [Fact]
//     public async Task UpdateUser_SuccessfullyUpdatesUser_WhenValidDataProvided()
//     {
//         //Arrange
//         var command = new UpdateUserCommand(User);
//         
//         _mockRepository
//             .Setup(repo => repo.GetByIdAsync(User.Id, It.IsAny<string>()))
//             .ReturnsAsync(User);
//
//         //Act
//         await _handler.Handle(command, default);
//
//         //Assert 
//         _mockRepository.Verify(repo => repo.UpdateAsync(It.Is<Core.Entities.User>(u => u.Id == User.Id)), Times.Once);
//     }
//
//     [Fact]
//     public async Task UpdateUser_ThrowsNotFoundException_WhenUserDoesNotExist()
//     {
//         //Arrange
//         var command = new UpdateUserCommand(User);
//
//         _mockRepository
//             .Setup(repo => repo.GetByIdAsync(User.Id, It.IsAny<string>()))
//             .ReturnsAsync((Core.Entities.User)null!);
//
//         //Act
//         var exception = await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, default));
//
//         //Assert 
//         Assert.Equal($"User with ID {User.Id} not found.", exception.Message);
//         _mockRepository.Verify(repo => repo.UpdateAsync(User), Times.Never);
//     }
//
// }