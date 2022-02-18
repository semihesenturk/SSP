using MediatR;
using SSP.Order.Application.Responses;

namespace SSP.Order.Application.Queries
{
    public class GetOrderByOrderNumberQuery : IRequest<OrderResponse>
    {
        #region Variables
        public string OrderNumber { get; set; }
        #endregion

        #region Constructor
        public GetOrderByOrderNumberQuery(string orderNumber)
        {
            OrderNumber = orderNumber;
        }
        #endregion
    }
}
