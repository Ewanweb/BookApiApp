using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Create
{
    public class ChangeCommentStatusCommandValidator : AbstractValidator<ChangeCommentStatusCommand>
    {
        public ChangeCommentStatusCommandValidator()
        {
            RuleFor(r => r.Status)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("وضعیت"));

        }
    }
}