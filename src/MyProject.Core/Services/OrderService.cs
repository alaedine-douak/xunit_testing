namespace MyProject.Core.Services;

public class OrderService
{
   public Order Create(Customer customer, decimal amount)
   {
      if (customer is null) 
      {
         throw new ArgumentNullException("Customer required!");
      }

      // Adding to Database

      return new Order(
         /* Getting the OrderId from DB */1233,
         customer.Id,
         10); 
   }
}
