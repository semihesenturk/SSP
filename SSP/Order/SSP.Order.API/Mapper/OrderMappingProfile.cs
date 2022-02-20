using AutoMapper;
using SSP.Order.API.Models.RequestModels;
using SSP.Order.Application.Commands.OrderCreate;

namespace SSP.Order.API.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderCreateRequestModel, OrderCreateCommand>().ReverseMap();
        }
    }
}
