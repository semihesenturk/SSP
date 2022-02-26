using AutoMapper;
using SSP.Order.Shared.Messages;
using SSP.Order.SL.API.Models.RequestModels;

namespace SSP.Order.SL.API.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderCreateRequestModel, OrderCreateMessage>().ReverseMap();
            CreateMap<OrderItemCreateRequestModel, OrderItemCreateMessage>().ReverseMap();
        }
    }
}
