using SSP.Order.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSP.Order.Domain.Entities
{
    public class OrderItem : Entity
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public virtual Order Order { get; set; }
    }
}
