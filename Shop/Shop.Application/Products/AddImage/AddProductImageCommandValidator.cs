using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommandValidator : AbstractValidator<AddProductImageCommand>
    { 
        public AddProductImageCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("عکس")).JustImageFile();

            RuleFor(r => r.Sequence)
                .GreaterThanOrEqualTo(0);
        }
    }

}