using MyProject.Core.Services;

namespace MyProject.Core.Tests.ServiceTests;

internal static class OrderAssertions
{
   extension(Order order)
   {
      internal void ShouldBeProcessed()
      {
         Assert.NotNull(order);
         Assert.Equal(OrderStatus.Processing, order.Status);
         Assert.NotNull(order.ProcessingId);
         Assert.True(order.ProcessedAt.HasValue, "Processed order should have a processing date.");
         Assert.False(string.IsNullOrWhiteSpace(order.ProcessingId), "Processed order should have a valid process ID");
      }

      internal void ShouldHaveValidCustomer(int customerId)
      {
         Assert.Equal(customerId, order.CutomerId);
         Assert.True(order.CutomerId > 0, "Order should have a valid customer");
      }

      internal void ShouldHaveValidItems()
      {
         Assert.NotNull(order.Items);
         Assert.NotEmpty(order.Items);
         Assert.All(order.Items, item =>
         {
            Assert.True(item.Quantity > 0, $"Item {item.ProductName} should have positive quantity");
            Assert.True(item.Price > 0, $"Item {item.ProductName} should have positive price");
            Assert.False(string.IsNullOrWhiteSpace(item.ProductName),
               $"Item with ProductId {item.ProductId} should have have a name");
         });
      }
   }
}
