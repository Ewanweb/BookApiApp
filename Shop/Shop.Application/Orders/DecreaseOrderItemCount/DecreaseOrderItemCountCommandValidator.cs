using FluentValidation;

namespace Shop.Application.Orders.DecreaseOrderItemCount
{
    public class DecreaseOrderItemCountCommandValidator : AbstractValidator<DecreaseOrderItemCountCommand>
    {
        public DecreaseOrderItemCountCommandValidator()
        {
            RuleFor(f => f.Count)
            .GreaterThanOrEqualTo(1).WithMessage("نعداد باید بیشتر از 0 باشد");
        }
    }
}