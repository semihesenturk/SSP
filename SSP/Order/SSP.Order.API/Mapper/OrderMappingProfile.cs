﻿using AutoMapper;
using SSP.Order.API.Models.RequestModels;
using SSP.Order.Application.Commands.OrderCreate;
using SSP.Order.Shared.Messages;

namespace SSP.Order.API.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderCreateRequestModel, OrderCreateCommand>().ReverseMap();
            CreateMap<OrderItemCreateRequestModel, Domain.Entities.OrderItem>().ReverseMap();

            CreateMap<OrderCreateMessage, OrderCreateCommand>().ReverseMap();
            CreateMap<OrderItemCreateMessage, Domain.Entities.OrderItem>().ReverseMap();
        }
    }
}
