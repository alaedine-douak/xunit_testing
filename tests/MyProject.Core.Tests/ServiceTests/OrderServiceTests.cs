using MyProject.Core.Services;

namespace MyProject.Core.Tests.ServiceTests;

public class OrderServiceTests
{

   private readonly OrderService _orderService;

   public OrderServiceTests()
   {
       _orderService = new OrderService();   
   }

   [Fact]
   public void ProcessOrder_ShouldThrowArgumentNullException_WhenOrderIsNull()
   {
      // Arrange

      Order? order = null;

      // Act && Assert

      var exception = Assert.Throws<ArgumentNullException>(() => _orderService.ProcessOrder(order!));

      Assert.Equal(nameof(order), exception.ParamName);
      Assert.Contains("Order is required", exception.Message);
   }

   [Fact]
   public void ProcessOrder_ShouldThrowArgumentNullException_WhenOrderStatusNotPending()
   {
      // Arrange
      var order = new Order 
      {
         Id = 1231,
         CutomerId = 1221,
         Amount = 219.99m,
         Status = OrderStatus.Processing,
      };

      // Act && Assert
      Assert.Throws<ArgumentNullException>(() => _orderService.ProcessOrder(order));
   }

   [Fact]
   public void ProcessOrder_ShouldMarkOrderAsProcessed_WhenOrderIsValid()
   {
      // Arrange
      var order = new Order
      {
         Id = 1,
         CutomerId = 1,
         Amount = 99.99m,
         Status = OrderStatus.Pending,
         Items = [new() { ProductId = 1, ProductName = "Test Product", Price = 99.99m, Quantity = 1 }]
      };

      // Act
      var result = _orderService.ProcessOrder(order);

      // Assert

      result.ShouldBeProcessed();
   }

   [Fact]
   public void IsOrderValid_ShouldReturnTrue_WhenOrderIsValid()
   {
      var order = new Order
      {
         CutomerId = 2,
         Amount = 99.99m,
         Items = [new() { ProductId = 1, ProductName = "Product 1", Price = 99.99m, Quantity = 1 }]
      };

      // Act
      var result = _orderService.IsOrderValid(order);

      // Assert
      Assert.True(result);

      order.ShouldHaveValidCustomer(2);

      order.ShouldHaveValidItems();
   }

   [Fact]
   public void ProcessOrder_ShouldReturnValidOrderWithFluentAssertion_WhenOrderIsValid()
   {
      // Arrange
      var order = new Order
      {
         CutomerId = 2,
         Amount = 99.99m,
         Items = [new() { ProductId = 1, ProductName = "Product 1", Price = 99.99m, Quantity = 1 }]
      };

      // Act
      var result = _orderService.ProcessOrder(order);

      // Assert

      result.Should().BeProcessed().HaveCustomer(2).HaveValidItems();
   }
}
