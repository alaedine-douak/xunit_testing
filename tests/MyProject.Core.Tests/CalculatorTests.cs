namespace MyProject.Core.Tests;

public class CalculatorTests
{
   private readonly Calculator _calculator = new();

   [Fact]
   public void Add_TwoPositiveNumbers_ReturnSum()
   {
      // arrange
      var firstNumber = 1;
      var secondNumber = 2;

      // act
      var result = _calculator.Add(firstNumber, secondNumber);

      // assert
      Assert.Equal(3, result);
   }

   [Fact]
   public void Add_TwoNegativeNumbers_ReturnSum()
   {
      // arrange
      var firstNumber = -3;
      var secondNumber = -2;

      // act
      var result = _calculator.Add(firstNumber, secondNumber);

      // assert
      Assert.Equal(-5, result);
   }
}
