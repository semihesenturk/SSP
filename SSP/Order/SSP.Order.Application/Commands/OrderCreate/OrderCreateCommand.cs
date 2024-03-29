﻿using MediatR;
using SSP.Order.Application.Responses;
using System;
using System.Collections.Generic;

namespace SSP.Order.Application.Commands.OrderCreate
{
    public class OrderCreateCommand : IRequest<OrderResponse>
    {
        public string OrderNumber { get; set; }
        public string OrderCustomerId { get; set; }
        public string OrderAddress { get; set; }
        public decimal OrderAmount { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Domain.Entities.OrderItem> OrderItems { get; set; }
    }
}
