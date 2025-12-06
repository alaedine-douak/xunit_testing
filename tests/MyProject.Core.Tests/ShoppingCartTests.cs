namespace MyProject.Core.Tests;

public class ShoppingCartTests
{
   private readonly ShoppingCart _shoppingCart;

   public ShoppingCartTests()
   {
       _shoppingCart = new ShoppingCart();
   }

   [Fact]
   public void ItemsCart_IsEmpty()
   {
      // Arrange & Act
      // Assert
      Assert.Empty(_shoppingCart.Items);
   }

   [Fact]
   public void AddItem_WithValidItem_AddsToCart()
   {
      // Arrange
      CartItem CartItem = new()
      {
         ProductId = 1,
         ProductName = "Laptop",
         Price = 669.99m,
         Quantity = 1
      };

      // Act
      _shoppingCart.AddItem(CartItem);

      // Assert
      Assert.NotEmpty(_shoppingCart.Items);
      var itemInCollection = Assert.Single(_shoppingCart.Items);
      Assert.Equal(1, itemInCollection.ProductId);
   }

   [Fact]
   public void GetExpensiveItems_WithThreshold_ReturnsFilteredItems()
   {
      // Arrange

      _shoppingCart.AddItem(new CartItem { ProductId = 1, ProductName = "Laptop", Price = 699.99m, Quantity = 1 });
      _shoppingCart.AddItem(new CartItem { ProductId = 2, ProductName = "Mouse", Price = 19.99m, Quantity = 1 });
      _shoppingCart.AddItem(new CartItem { ProductId = 3, ProductName = "Keyboard", Price = 79.99m, Quantity = 1 });

      // Act

      var expensiveItems = _shoppingCart.GetExpensiveItems(100.00m);

      // Assert - 
      Assert.Contains(expensiveItems, item => item.ProductName == "Laptop");
      Assert.DoesNotContain(expensiveItems, item => item.ProductName == "Mouse");

      Assert.All(expensiveItems, item => Assert.True(item.TotalPrice > 100m));
   }
}
