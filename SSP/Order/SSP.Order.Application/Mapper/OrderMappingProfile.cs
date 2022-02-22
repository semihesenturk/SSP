using AutoMapper;
using SSP.Order.Application.Commands.OrderCreate;
using SSP.Order.Application.Responses;

namespace SSP.Order.Application.Mapper
{
    public class OrderMappingProfile : Profile
    {
        #region Constructor
        public OrderMappingProfile()
        {
            CreateMap<Domain.Entities.Order, OrderCreateCommand>().ReverseMap();
            CreateMap<Domain.Entities.Order, OrderResponse>().ReverseMap();
            CreateMap<Domain.Entities.OrderItem, OrderItemResponse>().ReverseMap();
        }
        #endregion
    }
}
