using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSP.Order.Application.Commands.OrderCreate;
using SSP.Order.Application.Queries;
using SSP.Order.Application.Responses;
using System.Net;
using System.Threading.Tasks;

namespace SSP.Order.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;
        #endregion

        #region Constructor
        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        #endregion

        #region Crud Operations
        [HttpGet("GetOrderByOrderNumber/{orderNumber}")]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<OrderResponse>> GetOrderByOrderNumber(string orderNumber)
        {
            var query = new GetOrderByOrderNumberQuery(orderNumber);

            var order = await _mediator.Send(query);

            if (order == null)
                return NotFound("Order couldn't found");

            return Ok(order);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<OrderResponse>> OrderCreate([FromBody] OrderCreateCommand command)
        {

            var result = await _mediator.Send(command);
            if (result == null)
                return BadRequest("Order can not create!");

            return Ok(result);
        }
        #endregion
    }
}
