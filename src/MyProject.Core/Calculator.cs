namespace MyProject.Core;

public class Calculator
{
   public int Add(int number1, int number2) 
   {
      return number1 + number2;
   } 

   public double Devide(double num1, double num2)
   {
      if (num2 == 0) throw new DevideByZeroException();

      return num1/num2;
   }
}
