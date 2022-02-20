using System;
namespace SSP.Order.API.Models.RequestModels
{
    public class OrderCreateRequestModel
    {
        public string OrderNumber { get; set; }
        public string OrderCustomerId { get; set; }
        public string OrderAddress { get; set; }
        public decimal OrderAmount { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        //public List<OrderItem> OrderItems { get; set; }
    }
}
