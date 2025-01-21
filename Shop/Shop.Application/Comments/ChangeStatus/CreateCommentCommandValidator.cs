using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.ChangeStatus
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