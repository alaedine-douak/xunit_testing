using MyProject.Core.Services;

namespace MyProject.Core.Tests.ServiceTests;

public class OrderServiceTests
{
   private const int ORDER_AMOUNT = 10;

   private readonly OrderService _orderService;

   public OrderServiceTests()
   {
       _orderService = new OrderService();   
   }


   [Fact]
   public void CreateOrder_WithValidCustomerAndAmount_ReturnsValidOrder()
   {
      // Arrange
      const int CUSTOMER_ID = 1251;
      Customer customer = CreateCustomer(CUSTOMER_ID);

      // Act
      Order order = _orderService.Create(customer, ORDER_AMOUNT);

      // Assert
      Assert.NotNull(order);
      Assert.Equal(CUSTOMER_ID, order.CustomerId);
      Assert.Equal(ORDER_AMOUNT, order.Amount);
   }

   [Fact]
   public void CreateOrder_WithoutCustomer_ThrowsException()
   {
      // Arrange
      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => _orderService.Create(null!, ORDER_AMOUNT));
   }

   private static Customer CreateCustomer(int id = 1243) => new Customer(Id: id);

}
