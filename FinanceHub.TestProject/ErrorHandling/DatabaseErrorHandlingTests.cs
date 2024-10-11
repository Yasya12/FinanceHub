using FinanceGub.Application.Features.UserFeatures.Queries.GetUserQuery;
using FinanceGub.Application.Interfaces.Repositories;
using Moq;

namespace FinanceHub.TestProject.ErrorHandling
{
    public class DatabaseErrorHandlingTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly GetUserQueryHandler _handler;

        public DatabaseErrorHandlingTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new GetUserQueryHandler(_mockUserRepository.Object);
        }

        [Fact]
        public async Task DatabaseError_ThrowsException_WhenDatabaseUnavailable()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var query = new GetUserQuery(userId, It.IsAny<string>());

            _mockUserRepository
                .Setup(repo => repo.GetByIdAsync(userId, It.IsAny<string>()))
                .ThrowsAsync(new Exception("Database is unavailable."));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(query, default));
            Assert.Equal("Database is unavailable.", exception.Message);
        }
    }
}