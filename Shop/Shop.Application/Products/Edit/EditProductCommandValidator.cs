using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.Edit
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Description)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(r => r.ImageFile)
                .JustImageFile();

            RuleFor(r => r.Slug)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("اسلاگ"));
        }
    }

}