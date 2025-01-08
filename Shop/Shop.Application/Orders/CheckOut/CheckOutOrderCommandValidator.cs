using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommandValidator : AbstractValidator<CheckOutOrderCommand>
    {
        public CheckOutOrderCommandValidator()
        {
            RuleFor(f=> f.Name)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("نام"));

            RuleFor(f=> f.Family)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(f=> f.City)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("شهر"));

            RuleFor(f=> f.Shire)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("استان"));

            RuleFor(f=> f.PostalAddress)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("ادرس"));

            RuleFor(f=> f.PostalCode)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("کد پستی"));

            RuleFor(f=> f.PhoneNumber)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("شماره موبایل"))
                .MaximumLength(11).WithMessage("شماره موبایل نامعتبر است")
                .MinimumLength(11).WithMessage("شماره موبایل نامعتبر است");

            RuleFor(f=> f.NationalCode)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("کدملی"))
                .MaximumLength(11).WithMessage("کدملی موبایل نامعتبر است")
                .MinimumLength(11).WithMessage("کدملی موبایل نامعتبر است")
                .ValidNationalId();
        }
    }
}