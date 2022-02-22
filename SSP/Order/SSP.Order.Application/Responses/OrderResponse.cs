using System;
using System.Collections.Generic;

namespace SSP.Order.Application.Responses
{
    public class OrderResponse
    {
        public string OrderNumber { get; set; }
        public string OrderCustomerId { get; set; }
        public string OrderAddress { get; set; }
        public decimal OrderAmount { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemResponse> OrderItems { get; set; }
    }
}
