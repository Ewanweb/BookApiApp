using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommandValidator : AbstractValidator<EditBannerCommand>
    {
        public EditBannerCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(r => r.Link)
                .NotNull().WithMessage(ValidationMessages.required("لینک"));
        }
    }
}
