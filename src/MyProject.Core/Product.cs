namespace MyProject.Core;

public class Product
{
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public decimal Price { get; set; } = 0.0M;

   public override bool Equals(object? obj)
   {
      if (obj is not Product product) return false;
      return Id == product.Id && Name == product.Name && Price == product.Price;
   }

   public override int GetHashCode()
   {
      return HashCode.Combine(Id, Name, Price);
   }
}
