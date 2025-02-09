namespace Sports_Store.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public void RemoveItem(long productId)
        {
            var item = Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public decimal CalculateTotal()
        {
            return Items.Sum(i => i.Product.Price * i.Quantity);
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}