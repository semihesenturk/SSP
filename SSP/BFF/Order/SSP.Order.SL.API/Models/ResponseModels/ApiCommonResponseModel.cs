namespace SSP.Order.SL.API.Models.ResponseModels
{
    public class ApiCommonResponseModel
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
