using FluentValidation;
using SSP.Order.API.Models.RequestModels;

namespace SSP.Order.API.Validations
{
    public class OrderValidator : AbstractValidator<OrderCreateRequestModel>
    {
        public OrderValidator()
        {
            //RuleFor(x => x.OrderNumber).NotEmpty().WithMessage("OrderNumber can not be null!");
        }
    }
}
