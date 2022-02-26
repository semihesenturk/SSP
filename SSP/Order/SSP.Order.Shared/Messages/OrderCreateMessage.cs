using System;
using System.Collections.Generic;

namespace SSP.Order.Shared.Messages
{
    public class OrderCreateMessage
    {
        public string OrderNumber { get; set; }
        public string OrderCustomerId { get; set; }
        public string OrderAddress { get; set; }
        public decimal OrderAmount { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemCreateMessage> OrderItems { get; set; } = new List<OrderItemCreateMessage>();
    }
    public class OrderItemCreateMessage
    {
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
