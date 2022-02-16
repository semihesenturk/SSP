using FluentValidation;

namespace SSP.Order.Application.Commands.OrderCreate
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateCommand>
    {
        #region Constructor
        public OrderCreateValidator()
        {
            RuleFor(v => v.OrderNumber)
                .NotEmpty()
                .Length(0);
        }
        #endregion
    }
}
