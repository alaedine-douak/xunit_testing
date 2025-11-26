namespace MyProject.Core.Tests;

public class NumberValidatorTests
{
   private readonly NumberValidator _numberValidator;

   public NumberValidatorTests()
   {
       _numberValidator = new NumberValidator();
   }


   [Fact]
   public void IsEven_GivenEvenNumber_ReturnsTrue()
   {
      int evenNumber = 4;

      bool result = _numberValidator.IsEven(evenNumber);

      Assert.True(result);
   }

   [Fact]
   public void IsEven_GivenOddNumber_ReturnsFalse()
   {
      int oddNumber = 11;

      bool result = _numberValidator.IsEven(oddNumber);

      Assert.False(result);
   }

   [Fact]
   public void IsInRange_NumberInRange_ReturnsTrue()
   {
      int num = 3;
      int min = 1;
      int max = 7;


      bool result = _numberValidator.IsInRange(num, min, max);


      Assert.True(true);
   }

   [Fact]
   public void IsInRange_GivenNumberOutOfRange_ReturnsFalse()
   {
      int num = 9;
      int min = 1;
      int max = 7;

      bool result = _numberValidator.IsInRange(num, min, max);

      Assert.False(result);
   }
}
