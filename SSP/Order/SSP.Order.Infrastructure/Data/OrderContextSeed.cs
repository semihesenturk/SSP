using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSP.Order.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext)
        {
            if (orderContext.Orders.Any())
            {
                return;
            }
            orderContext.Orders.AddRange(PreconfiguredOrders);
            await orderContext.SaveChangesAsync();
        }

        private static IEnumerable<Domain.Entities.Order> PreconfiguredOrders => new List<Domain.Entities.Order>()
            {
                new Domain.Entities.Order()
                {
                    OrderNumber ="1",
                    OrderCustomerId="1",
                    OrderAddress ="Yeni mahalle küme sokak no:65 küçükçekmece istanbul",
                    OrderAmount =100,
                    Description ="Seed",
                    OrderDate =System.DateTime.Now
                    //OrderItems = new List<Domain.Entities.OrderItem>()
                    //{
                    //    new Domain.Entities.OrderItem()
                    //      {
                    //        OrderId=1,
                    //        ProductCode ="P1",
                    //        Description="Seed",
                    //        ProductPrice=100,
                    //        Quantity=1
                    //    }
                    //}
                },
                new Domain.Entities.Order()
                {
                    OrderNumber ="2",
                    OrderCustomerId="2",
                    OrderAddress ="Yeni mahalle küme sokak no:65 küçükçekmece istanbul",
                    OrderAmount =150,
                    Description ="Seed",
                    OrderDate =System.DateTime.Now
                    //OrderItems = new List<Domain.Entities.OrderItem>()
                    //{
                    //    new Domain.Entities.OrderItem()
                    //      {
                    //        OrderId=1,
                    //        ProductCode ="P1",
                    //        Description="Seed",
                    //        ProductPrice=75,
                    //        Quantity=2
                    //    }
                    //}
                }
            };
    }
}
