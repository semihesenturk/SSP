using AutoMapper;
using MediatR;
using SSP.Order.Application.Queries;
using SSP.Order.Application.Responses;
using SSP.Order.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SSP.Order.Application.Handlers
{
    public class GetOrderByOrderNumberHandler : IRequestHandler<GetOrderByOrderNumberQuery, OrderResponse>
    {
        #region Variables
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetOrderByOrderNumberHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        #endregion


        public async Task<OrderResponse> Handle(GetOrderByOrderNumberQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByOrderNumber(request.OrderNumber);

            var response = _mapper.Map<OrderResponse>(order);

            return response;
        }
    }
}
