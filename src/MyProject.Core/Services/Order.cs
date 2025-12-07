namespace MyProject.Core.Services;

internal enum OrderStatus
{
   Pending,
   Processing,
   Shipped,
   Delivered,
   Cancelled
}

internal class OrderItem
{
   public int ProductId { get; set; }
   public string ProductName { get; set; } = string.Empty;
   public decimal Price { get; set; }
   public int Quantity { get; set; }

   public decimal TotalPrice => Price * Quantity;
}

internal class Order
{
   public int Id { get; set; }
   public int CutomerId { get; set; }
   public decimal Amount { get; set; }
   public OrderStatus Status { get; set; } = OrderStatus.Pending;
   public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
   public DateTime? ProcessedAt { get; set; }
   public string? ProcessingId { get; set; }
   public List<OrderItem> Items { get; set; } = [];
}
