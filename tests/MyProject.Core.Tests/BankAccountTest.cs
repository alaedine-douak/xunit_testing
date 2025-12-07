namespace MyProject.Core.Tests;

public class BankAccountTest
{
   [Fact]
   public void Withdraw_WithInsufficientFunds_ThrowsInsufficientException()
   {
      // Arrange
      BankAccount account = new("ACC-001", 50.00m);

      // Act & Assert - Test custom exception
      var exception = Assert.Throws<InsufficientFundsException>(() => account.Withdraw(100.00m));

      // Validate custom exception properties
      Assert.Equal("ACC-001", exception.AccountId);
      Assert.Equal(50m, exception.AvailableBalance);
      Assert.Equal(100m, exception.RequestedAmount);
      Assert.StartsWith("Insufficient funds in account", exception.Message);
   }
}
