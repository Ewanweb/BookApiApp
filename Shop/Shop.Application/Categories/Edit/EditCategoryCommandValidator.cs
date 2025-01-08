using FluentValidation;
using Common.Application.Validation;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("اسلاگ"));
        }
    }
}