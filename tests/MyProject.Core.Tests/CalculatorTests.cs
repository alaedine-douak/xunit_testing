namespace MyProject.Core.Tests;

public class CalculatorTests
{
   private readonly Calculator _calculator;

   public CalculatorTests()
   {
       _calculator = new Calculator();
   }

   [Fact]
   public void Add_1And2_Returns3()
   {
      int a = 1;
      int b = 2;

      var result = _calculator.Add(a, b);

      Assert.Equal(3, result);
   }

   [Theory]
   [InlineData([-1, 2, 1])]
   [InlineData([2, 3, 5])]
   [InlineData([3, 12, 15])]
   public void Add_TwoNumbers_ReturnsExpectedResult(int a, int b, int expectedResult)
   {
      int result = _calculator.Add(a, b);

      Assert.Equal(expectedResult, result);
   }

   [Theory]
   [InlineData([4, 2, 2])]
   [InlineData([30, 15, 2])]
   [InlineData([2.5, 1, 2.5])]
   [InlineData([1.5, 2, 0.75])]
   [InlineData([0, 2, 0])]
   public void Devide_Given2Numbers_ReturnsExpectedResult(double a, double b, double expectedResult)
   {
      double result = _calculator.Devide(a, b);

      Assert.Equal(expectedResult, result);
   }

   [Fact]
   public void Devide_ByZero_ThrowsException()
   {
      int num1 = 3;
      int num2 = 0;

      Action result = () => _calculator.Devide(num1, num2);

      Assert.Throws<DevideByZeroException>(result);
   }

   [Fact]
   public void CalculateAverage_WithValidArray_ReturnsCorrectAverage()
   {
      // Arrange
      double[] values = [2.0, 4.0, 6.0];

      // Act
      double result = _calculator.CalculateAverage(values);

      // Assert - NOTE: using precision for floating-point comparison
      Assert.Equal(4.0, result, precision: 2);
   }
}
