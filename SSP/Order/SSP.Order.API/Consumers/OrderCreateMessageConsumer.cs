using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SSP.Order.Application.Commands.OrderCreate;
using SSP.Order.Shared.Messages;
using System.Threading.Tasks;

namespace SSP.Order.API.Consumers
{
    public class OrderCreateMessageConsumer : IConsumer<OrderCreateMessage>
    {
        #region Variables
        private readonly IMediator _mediator;
        private readonly ILogger<OrderCreateMessageConsumer> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public OrderCreateMessageConsumer(IMediator mediator, ILogger<OrderCreateMessageConsumer> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion

        public async Task Consume(ConsumeContext<OrderCreateMessage> context)
        {
            var orderCreateCommand = _mapper.Map<OrderCreateCommand>(context.Message);

            var order = await _mediator.Send(orderCreateCommand);
        }
    }
}

