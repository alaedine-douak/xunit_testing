namespace MyProject.Core.Services;

internal class OrderService
{
   private static int _nextProcessingId = 100;

   internal Order ProcessOrder(Order order)
   {
      if (order is not { Status: OrderStatus.Pending }) 
      { 
         throw new ArgumentNullException(nameof(order), "Order is required and must be pending");
      }

      order.Status = OrderStatus.Processing;
      order.ProcessedAt = DateTime.UtcNow;
      order.ProcessingId = $"proc-{DateTime.UtcNow:yyyyMMdd}-{_nextProcessingId:D4}";

      _nextProcessingId++;

      return order;
   }

   internal decimal CalculateOrderTotal(Order order)
   {
      if (order is { Items: [] }) return 0;

      return order.Items.Sum(i => i.TotalPrice);
   }

   internal bool IsOrderValid(Order order) =>
      order is not null &&
      order is { CutomerId: > 0, Amount: > 0, Items: not [] } &&
      order.Items.All(item => item is { Quantity: > 0, Price: > 0m });
}
