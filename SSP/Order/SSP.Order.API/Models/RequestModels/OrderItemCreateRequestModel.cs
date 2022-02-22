namespace SSP.Order.API.Models.RequestModels
{
    public class OrderItemCreateRequestModel
    {
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
