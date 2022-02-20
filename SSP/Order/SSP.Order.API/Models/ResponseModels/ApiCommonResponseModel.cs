namespace SSP.Order.API.Models.ResponseModels
{
    public class ApiCommonResponseModel
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public object Data { get; set; }
    }
}
