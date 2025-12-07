using MyProject.Core.Services;

namespace MyProject.Core.Tests.ServiceTests;

internal static class FluentOrderAssertion
{
   extension(Order order)
   {
      public OrderAssertion Should()
      {
         return new OrderAssertion(order);
      }
   }
}

internal class OrderAssertion
{
   private readonly Order _order;

   public OrderAssertion(Order order)
   {
      _order = order;
   }

   public OrderAssertion HaveCustomer(int customerId)
   {
      _order.ShouldHaveValidCustomer(customerId);
      return this;
   }

   public OrderAssertion HaveValidItems()
   {
      _order.ShouldHaveValidItems();
      return this;
   }

   public OrderAssertion BeProcessed()
   {
      _order.ShouldBeProcessed();
      return this;
   }
}
