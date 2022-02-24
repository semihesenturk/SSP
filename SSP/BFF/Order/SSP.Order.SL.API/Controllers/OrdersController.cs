using Microsoft.AspNetCore.Mvc;
using SSP.Order.SL.API.Models.RequestModels;
using SSP.Order.SL.API.Models.ResponseModels;
using System.Net;
using System.Threading.Tasks;

namespace SSP.Order.SL.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
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

            return response;
        }
    }
}
