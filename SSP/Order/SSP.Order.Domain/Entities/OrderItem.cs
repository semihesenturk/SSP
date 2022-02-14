namespace SSP.Order.Domain.Entities
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
