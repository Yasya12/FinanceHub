// using FinanceGub.Application.Features.UserFeatures.Queries.GetUserQuery;
// using FinanceGub.Application.Interfaces.Repositories;
// using FinanceHub.Core.Exceptions;
// using Moq;
//
// namespace FinanceHub.TestProject.Queries.User;
//
// public class GetUserByIdQueryTests
// {
//     private readonly Mock<IUserRepository> _mockUserRepository;
//     private readonly GetUserQueryHandler _handler;
//
//     public GetUserByIdQueryTests()
//     {
//         _mockUserRepository = new Mock<IUserRepository>();
//         _handler = new GetUserQueryHandler(_mockUserRepository.Object);
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
//     public async Task GetUserById_ReturnsCorrectUser_WhenUserExists()
//     {
//         //Arrange
//         var query = new GetUserQuery(User.Id, It.IsAny<string>());
//
//         _mockUserRepository
//             .Setup(repo => repo.GetByIdAsync(User.Id, It.IsAny<string>()))
//             .ReturnsAsync(User);
//
//         //Act
//         var result = await _handler.Handle(query, default);
//
//         //Assert
//         _mockUserRepository.Verify(repo => repo.GetByIdAsync(User.Id, It.IsAny<string>()), Times.Once);
//         Assert.Equal(User, result);
//     }
//
//     [Fact]
//     public async Task GetUserById_ThrowsNotFoundException_WhenUserDoesNotExist()
//     {
//         // Arrange
//         var query = new GetUserQuery(User.Id, It.IsAny<string>());
//
//         _mockUserRepository
//             .Setup(repo => repo.GetByIdAsync(User.Id, It.IsAny<string>()))
//             .ThrowsAsync(new NotFoundException($"Entity of type {nameof(Core.Entities.User)} with id {User.Id} was not found."));
//
//         // Act & Assert
//         var exception = await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, default));
//
//         // Assert
//         Assert.Equal($"Entity of type {nameof(Core.Entities.User)} with id {User.Id} was not found.", exception.Message);
//         _mockUserRepository.Verify(repo => repo.GetByIdAsync(User.Id, It.IsAny<string>()), Times.Once);
//     }
// }