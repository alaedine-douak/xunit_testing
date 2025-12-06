namespace MyProject.Core;

public class Calculator
{
   public int Add(int number1, int number2) => number1 + number2;

   public double Devide(double num1, double num2) =>
      num2 == 0 ? throw new DevideByZeroException() : num1 / num2;


   public double CalculateAverage(double[] values)
   {
      //if (values is null or []) throw new ArgumentException("Value cannot be null or empty");
      //return ;


      return values is null or []
         ? throw new ArgumentException("Value cannot be null or empty") : (values.Sum() / values.Length);
   }
}
