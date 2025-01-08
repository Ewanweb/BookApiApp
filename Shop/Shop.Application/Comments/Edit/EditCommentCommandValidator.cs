using FluentValidation;
using Common.Application.Validation;

namespace Shop.Application.Categories.Edit
{
    public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
    {
        public EditCommentCommandValidator()
        {
            RuleFor(r => r.Text)
                .NotNull()
                .MinimumLength(5).WithMessage(ValidationMessages.minLength("Text",5));
        }
    }
}