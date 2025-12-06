namespace MyProject.Core.Tests;

public class ProductTests
{
   [Fact]
   public void Product_WithSameValue_AreEqual()
   {
      // Arrange
      var product1 = new Product { Id = 1, Name = "Mouse", Price = 12.99M };
      var product2 = new Product { Id = 1, Name = "Mouse", Price = 12.99M };

      // Act & Assert - testing value equality vs reference equality
      Assert.Equal(product1, product2); // compare the object's values
      Assert.NotSame(product1, product2); // compare instance [reference in memory]



      //Assert.NotEqual(product1, product2);
   }
}
