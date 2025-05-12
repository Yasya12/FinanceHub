// using FinanceGub.Application.Features.UserFeatures.Queries;
// using FinanceGub.Application.Features.UserFeatures.Queries.GetAllUserQuery;
// using FinanceGub.Application.Interfaces.Repositories;
// using Moq;
//
// namespace FinanceHub.TestProject.Queries.User;
//
// public class GetAllUsersQueryTests
// {
//     private readonly Mock<IUserRepository> _mockUserRepository;
//     private readonly GetAllUserQueryHandler _handler;
//
//     public GetAllUsersQueryTests()
//     {
//         _mockUserRepository = new Mock<IUserRepository>();
//         _handler = new GetAllUserQueryHandler(_mockUserRepository.Object);
//     }
//     
//     [Fact]
//     public async Task GetAllUsers_ReturnsListOfUsers_WhenUsersExist()
//     {
//         // Arrange
//         var query = new GetAllUserQuery(It.IsAny<string>());
//
//         var userList = new List<Core.Entities.User>
//         {
//             new Core.Entities.User { Id = Guid.NewGuid(), Username = "user1", Email = "user1@gmail.com" },
//             new Core.Entities.User { Id = Guid.NewGuid(), Username = "user2", Email = "user2@gmail.com" }
//         };
//
//         _mockUserRepository
//             .Setup(repo => repo.GetAllAsync(It.IsAny<string>()))
//             .ReturnsAsync(userList);
//
//         // Act
//         var result = await _handler.Handle(query, default);
//
//         // Assert
//         Assert.NotNull(result);
//         Assert.Equal(userList.Count, result.Count()); 
//         _mockUserRepository.Verify(repo => repo.GetAllAsync(It.IsAny<string>()), Times.Once);
//     }
//
//
//
//
//     [Fact]
//     public async Task GetAllUsers_ReturnsEmptyList_WhenNoUsersExist()
//     {
//         // Arrange
//         var query = new GetAllUserQuery(It.IsAny<string>());
//     
//         var emptyUserList = new List<Core.Entities.User>();
//
//         _mockUserRepository
//             .Setup(repo => repo.GetAllAsync(It.IsAny<string>()))
//             .ReturnsAsync(emptyUserList);
//
//         // Act
//         var result = await _handler.Handle(query, default);
//
//         // Assert
//         Assert.NotNull(result);
//         Assert.Empty(result);
//         _mockUserRepository.Verify(repo => repo.GetAllAsync(It.IsAny<string>()), Times.Once);
//     }
// }