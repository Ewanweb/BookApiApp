using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create
{
    public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        }
    }
}
