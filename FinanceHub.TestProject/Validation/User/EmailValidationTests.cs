using System.ComponentModel.DataAnnotations;

namespace FinanceHub.TestProject.Validation.User;

public class EmailValidationTests
{
    [Fact]
    public void EmailValidation_ThrowsException_WhenEmailIsInvalid()
    {
        // Arrange
        var user = new Core.Entities.User
        {
            Username = "validUsername",
            Email = "invalid-email", 
            PasswordHash = "validPasswordHash"
        };

        // Act & Assert
        var exception = Assert.Throws<ValidationException>(() => ValidateModel(user));

        Assert.Contains("Invalid Email Address", exception.Message);
    }

    private void ValidateModel(Core.Entities.User user)
    {
        var context = new ValidationContext(user, null, null);
        Validator.ValidateObject(user, context, true);
    }
}