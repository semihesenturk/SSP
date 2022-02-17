using AutoMapper;
using MediatR;
using SSP.Order.Application.Commands.OrderCreate;
using SSP.Order.Application.Responses;
using SSP.Order.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SSP.Order.Application.Handlers
{
    public class OrderCreateHandler : IRequestHandler<OrderCreateCommand, OrderResponse>
    {
        #region Variables
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public OrderCreateHandler(IMapper mapper,
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        #endregion

        public async Task<OrderResponse> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Domain.Entities.Order>(request);
            if (orderEntity == null)
                throw new ApplicationException("Entity couldn't be mapped!");

            var order = await _orderRepository.AddASync(orderEntity);

            var orderResponse = _mapper.Map<OrderResponse>(order);

            return orderResponse;
        }
    }
}
