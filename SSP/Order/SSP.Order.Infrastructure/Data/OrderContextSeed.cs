using Bogus;
using SSP.Order.Shared.Enums;
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

        private static IEnumerable<Domain.Entities.Order> PreconfiguredOrders = GetFakeObjects();

        private static IEnumerable<Domain.Entities.Order> GetFakeObjects()
        {
            //Creating fake orders with Bogus tool.
            var orderFaker = new Faker<Domain.Entities.Order>("tr")
                 .RuleFor(i => i.OrderNumber, i => i.Random.Int(1, 9999).ToString())
                 .RuleFor(i => i.OrderAddress, i => i.Address.FullAddress())
                 .RuleFor(i => i.OrderDate, i => i.Date.Recent())
                 .RuleFor(i => i.OrderAmount, i => i.Finance.Amount())
                 .RuleFor(i => i.OrderCustomerId, i => i.Random.Int().ToString())
                 .RuleFor(i => i.Description, i => i.Commerce.ProductDescription())
                 .RuleFor(i => i.Status, i => i.PickRandom<OrderStatusEnum>())

                 .RuleFor(i => i.CreatedUserId, i => i.Random.Int())
                 .RuleFor(i => i.IsActive, i => i.Random.Bool())
                 .RuleFor(i => i.CreatedDate, i => i.Date.Recent());

            return orderFaker.Generate(5);
        }


    }
}
