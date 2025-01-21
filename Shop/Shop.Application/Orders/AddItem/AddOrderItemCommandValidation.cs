using FluentValidation;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandValidation : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemCommandValidation()
        {
            RuleFor(r => r.count)
                .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 عدد باشد");
        }
    }
