using FluentValidation;

namespace Shop.Application.Orders.IncreaseOrderItemCount
{
    public class IncreaseOrderItemCountCommandValidator : AbstractValidator<IncreaseOrderItemCountCommand>
    {
        public IncreaseOrderItemCountCommandValidator()
        {
            RuleFor(f => f.Count)
            .GreaterThanOrEqualTo(1).WithMessage("نعداد باید بیشتر از 0 باشد");
        }
    }
}