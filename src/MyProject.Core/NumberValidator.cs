namespace MyProject.Core;

public class NumberValidator
{
   public bool IsEven(int number) => number % 2 == 0;

   public bool IsInRange(int number, int min, int max) => number >= min && number <= max; 
}
