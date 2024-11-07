namespace CoolShopFlowers.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }  // Зовнішній ключ
        public int FlowerId { get; set; }  // Зовнішній ключ
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Навігаційні властивості
        public Order? Order { get; set; }
        public Flower? Flower { get; set; }
    }

}
