namespace bangazon.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductItemId { get; set; }
        public int OrderId { get; set; }
        public ProductItem ProductItem { get; set; }
        public Order Order { get; set; }

        public decimal Price => ProductItem?.Price ?? 0;
    }
}
