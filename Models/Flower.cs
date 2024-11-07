namespace CoolShopFlowers.Models
{
    public class Flower
    {
        public int FlowerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? CategoryId { get; set; }  // Зовнішній ключ

        // Навігаційні властивості
        public Category? Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
