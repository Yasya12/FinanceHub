using System.ComponentModel.DataAnnotations;

namespace FinanceHub.TestProject.Validation.User
{
    public class UserameValidationTests
    {
        [Fact]
        public void UsernameValidation_ThrowsException_WhenUsernameIsEmpty()
        {
            // Arrange
            var user = new Core.Entities.User
            {
                Username = string.Empty, 
                Email = "test@gmail.com",
                PasswordHash = "validPasswordHash"
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.NotEmpty(validationResults);
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("The Username field is required."));
        }

        [Fact]
        public void UsernameValidation_ThrowsException_WhenUsernameTooShort()
        {
            // Arrange
            var user = new Core.Entities.User
            {
                Username = "ab",
                Email = "validemail@example.com",
                PasswordHash = "validPasswordHash"
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.NotEmpty(validationResults); 
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("The field Username must be a string with a minimum length of 3 and a maximum length of 20."));
        }
        
        [Fact]
        public void UsernameValidation_ThrowsException_WhenUsernameContainsInvalidCharacters()
        {
            // Arrange
            var user = new Core.Entities.User
            {
                Username = "invalid username!", 
                Email = "test@gmail.com",
                PasswordHash = "validPasswordHash"
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.NotEmpty(validationResults);
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Username can only contain letters, numbers, and underscores."));
        }

        private IList<ValidationResult> ValidateModel(Core.Entities.User user)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(user, null, null);
            Validator.TryValidateObject(user, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
