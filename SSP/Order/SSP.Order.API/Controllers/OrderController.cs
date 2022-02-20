using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSP.Order.API.Models.RequestModels;
using SSP.Order.API.Models.ResponseModels;
using SSP.Order.Application.Commands.OrderCreate;
using SSP.Order.Application.Queries;
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
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public OrderController(IMediator mediator, ILogger<OrderController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion

        #region Crud Operations
        [HttpGet("GetOrderByOrderNumber/{orderNumber}")]
        [ProducesResponseType(typeof(ApiCommonResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ApiCommonResponseModel>> GetOrderByOrderNumber(string orderNumber)
        {
            ApiCommonResponseModel response = new ApiCommonResponseModel();

            var query = new GetOrderByOrderNumberQuery(orderNumber);

            var order = await _mediator.Send(query);
            if (order == null)
            {
                response.Data = null;
                response.StatusCode = 500;
                response.ErrorMessage = "Order couldn't found on db!";

                _logger.LogError($"Order couldn't found on db with ordernumber: {orderNumber}");
                return response;
            }
            else
            {
                response.Data = order;
                response.StatusCode = 200;
                response.ErrorMessage = null;

                _logger.LogInformation($"Order get operation success with ordernumber: {orderNumber}");
                return response;
            }
        }

        [HttpPost()]
        [ProducesResponseType(typeof(ApiCommonResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiCommonResponseModel>> OrderCreate([FromBody] OrderCreateRequestModel requestModel)
        {
            ApiCommonResponseModel response = new ApiCommonResponseModel();
            OrderCreateCommand orderCreateCommand = _mapper.Map<OrderCreateCommand>(requestModel);

            var result = await _mediator.Send(orderCreateCommand);
            if (result == null)
            {
                response.StatusCode = 500;
                response.ErrorMessage = "Order can not created!";
                response.Data = null;

                _logger.LogError("Order create operation finished with a error!");
                return response;
            }
            else
            {
                response.StatusCode = 200;
                response.ErrorMessage = null;
                response.Data = result;

                _logger.LogInformation($"Order created with ordernumber {result.OrderNumber}");
                return response;
            }
        }
        #endregion
    }
}
