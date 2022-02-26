using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSP.Order.Shared.Messages;
using SSP.Order.SL.API.Models.RequestModels;
using SSP.Order.SL.API.Models.ResponseModels;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SSP.Order.SL.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Variables
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        #endregion

        #region Constructor
        public OrdersController(IMapper mapper, ILogger<OrdersController> logger, IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }
        #endregion

        [HttpGet("")]
        [ProducesResponseType(typeof(ApiCommonResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ApiCommonResponseModel>> GetOrders()
        {
            ApiCommonResponseModel response = new ApiCommonResponseModel();


            return response;
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(ApiCommonResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ApiCommonResponseModel>> GetOrderById(int orderId)
        {
            ApiCommonResponseModel response = new ApiCommonResponseModel();

            return response;
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(ApiCommonResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ApiCommonResponseModel>> CreateOrder([FromBody] OrderCreateRequestModel orderCreateRequestModel)
        {
            ApiCommonResponseModel response = new ApiCommonResponseModel();
            try
            {
                OrderCreateMessage orderCreateMessage = _mapper.Map<OrderCreateMessage>(orderCreateRequestModel);

                await _publishEndpoint.Publish(orderCreateMessage);

                response.StatusCode = 200;
                response.Data = orderCreateMessage;
                response.ErrorMessage = string.Empty;

                _logger.LogInformation($"Order create message has sent to queue successfuly for {orderCreateRequestModel.OrderNumber}");
                return response;
            }
            catch (Exception)
            {

                response.StatusCode = 500;
                response.Data = null;
                response.ErrorMessage = $"Order create message can not send to queue for {orderCreateRequestModel.OrderNumber}";

                _logger.LogError($"Order create message can not send to queue for {orderCreateRequestModel.OrderNumber}");
                return response;
            }
        }
    }
}
