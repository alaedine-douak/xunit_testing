namespace MyProject.Core.Tests;

public class EmailValidatorTests
{

   // Naming & Documentation

   // MethodName_Scenario_ExpectedResult
   // Pattern breakdown:
   // MethodName: `IsValid` - What method/functionality is being tested
   // Scenario: `WhenIsAValidEmail` - What conditions or input state
   // ExpectedResult: `ShouldReturnTrue` - What should happen

   private readonly EmailValidator _emailValidator;

   public EmailValidatorTests()
   {
       _emailValidator = new EmailValidator();
   }

   [Fact]
   public void Validate_WithValidEmail_ReturnsValidResult()
   {
      // Arrange
      var email = "username@example.com";

      // Act
      var result = _emailValidator.Validate(email);

      // Assert
      Assert.True(result.IsValid);
      Assert.Empty(result.ErrorMessage);
      Assert.Empty(result.ErrorMessage);
   }

   [Fact]
   public void Validate_WithInvalidEmail_ReturnsInvalidResult()
   {
      // Arrange
      string email = "invalid_email";

      // Act
      var result = _emailValidator.Validate(email);

      // Assert
      Assert.False(result.IsValid);
      Assert.NotEmpty(result.ErrorMessage);
      Assert.Contains("Email address must contain an @ symbol", result.ErrorMessage);
   }

   [Fact]
   public void Validate_WithNullEmail_ReturnsAppropriateError()
   {
      // Arrange

      // Act
      var result = _emailValidator.Validate(null!);

      // Assert
      Assert.False(result.IsValid);
      Assert.StartsWith("Email address cannot", result.ErrorMessage);
      Assert.EndsWith("null or empty", result.ErrorMessage);
   }

   [Fact]
   public void Validate_WithEmailMissingAtSymbol_ReturnsSpecificError()
   {
      // Arrange
      string emailWithoutAtSymbol = "username_example.com";

      // Act
      var result = _emailValidator.Validate(emailWithoutAtSymbol);

      // Assert
      Assert.False(result.IsValid);
      Assert.Equal("EMAIL address must contain an @ symbol", 
         result.ErrorMessage,
         StringComparer.InvariantCultureIgnoreCase);
   }


   //[Fact(DisplayName = "Should return true if email is null")]
   //public void IsValid_WhenIsAValidEmail_ShouldReturnTrue()
   //{
   //   var validator = new EmailValidator();

   //   var result = validator.IsValid("user@example.com");

   //   Assert.True(result);
   //}

   //[Fact]
   //public void IsValid_WhenIsAnInvalidEmail_ShouldReturnFalse()
   //{
   //   var validator = new EmailValidator();

   //   var result = validator.IsValid("invalid");

   //   Assert.False(result);
   //}

   //[Fact]
   //public void IsValid_WhenEmailIsEmpty_ShouldReturnFalse()
   //{
   //   var validator = new EmailValidator();

   //   var result = validator.IsValid("");

   //   Assert.False(result);
   //}
}
