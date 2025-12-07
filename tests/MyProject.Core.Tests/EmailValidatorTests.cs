namespace MyProject.Core.Tests;

public class EmailValidatorTests
{

   private readonly EmailValidator _emailValidator;

   public EmailValidatorTests()
   {
       _emailValidator = new EmailValidator();
   }

   [Theory]
   [InlineData("user@example.com", true)]
   [InlineData("user.domain@example.com", true)]
   [InlineData("user-domain@example.or.dz", true)]
   public void IsValid_ShouldReturnsTrue_WhenEmailIsValid(string email, bool expectedResult)
   {
      // Arrange & Act
      var result = _emailValidator.IsValid(email);

      // Assert
      Assert.Equal(expectedResult, result);
   }

   [Theory]
   [InlineData("", false)]
   [InlineData(null, false)]
   [InlineData("userexample.com", false)]
   public void IsValid_ShouldReturnsFalse_WhenEmailIsInvalid(string email, bool expectedResult)
   {
      var result = _emailValidator.IsValid(email);

      Assert.Equal(expectedResult, result);
   }
}
