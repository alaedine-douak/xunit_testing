namespace MyProject.Core;

internal class CartItem
{
   public int ProductId { get; set; }
   public string ProductName { get; set; } = string.Empty;
   public decimal Price { get; set; }
   public int Quantity { get; set; }

   public decimal TotalPrice => Price * Quantity;
}

internal class ShoppingCart
{
   private readonly List<CartItem> _items = [];

   public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

   public void AddItem(CartItem item)
   {
      if (item is null) throw new ArgumentNullException(nameof(item));

      var existingItem = _items.FirstOrDefault(x => x.ProductId == item.ProductId);
      existingItem?.Quantity += item.Quantity;

      _items.Add(item);
   }

   public void RemoveAll(int productId) => _items.RemoveAll(i => i.ProductId == productId);

   public void Clear() => _items.Clear();

   public decimal GetTotalAmount() => _items.Sum(i => i.TotalPrice);

   public int GetTotalItemCount() => _items.Sum(i => i.Quantity);

   public bool HasItem(int productId) => _items.Any(i => i.ProductId == productId);

   public IEnumerable<CartItem> GetExpensiveItems(decimal threshold) => _items.Where(i => i.TotalPrice >= threshold); 
}
