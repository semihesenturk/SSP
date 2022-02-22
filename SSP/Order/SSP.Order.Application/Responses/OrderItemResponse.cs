namespace SSP.Order.Application.Responses
{
    public class OrderItemResponse
    {
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
