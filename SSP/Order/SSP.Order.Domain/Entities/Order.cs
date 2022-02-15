using SSP.Order.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace SSP.Order.Domain.Entities
{
    public class Order : Entity
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
