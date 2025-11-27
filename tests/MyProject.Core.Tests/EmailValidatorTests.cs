namespace MyProject.Core.Tests;

public class EmailValidatorTests
{

   // Naming & Documentation

   // MethodName_Scenario_ExpectedResult
   // Pattern breakdown:
   // MethodName: `IsValid` - What method/functionality is being tested
   // Scenario: `WhenIsAValidEmail` - What conditions or input state
   // ExpectedResult: `ShouldReturnTrue` - What should happen


   [Fact(DisplayName = "Should return true if email is null")]
   public void IsValid_WhenIsAValidEmail_ShouldReturnTrue()
   {
      var validator = new EmailValidator();

      var result = validator.IsValid("user@example.com");

      Assert.True(result);
   }

   [Fact]
   public void IsValid_WhenIsAnInvalidEmail_ShouldReturnFalse()
   {
      var validator = new EmailValidator();

      var result = validator.IsValid("invalid");

      Assert.False(result);
   }

   [Fact]
   public void IsValid_WhenEmailIsEmpty_ShouldReturnFalse()
   {
      var validator = new EmailValidator();

      var result = validator.IsValid("");

      Assert.False(result);
   }
}
