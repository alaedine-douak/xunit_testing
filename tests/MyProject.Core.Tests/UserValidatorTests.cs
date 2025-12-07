namespace MyProject.Core.Tests;

public class UserValidatorTests
{
   [Theory]
   [MemberData(nameof(GetValidUserScenarios))]
   public void Validate_ShouldReturnsTrue_WhenUsersValid(User user, string scenario)
   {
      // Arrange
      var validator = new UserValidator();

      // Act 

      var (isValid, message) = validator.Validate(user);

      // Assert
      Assert.True(isValid, $"scenario: {scenario}");
      Assert.Empty(message);
   }

   public static IEnumerable<object[]> GetValidUserScenarios()
   {
      yield return new object[] { new User("John", 25), "Standard valid user" };
      yield return new object[] { new User("Bob", 18), "Minimum age user" };
   }
}
