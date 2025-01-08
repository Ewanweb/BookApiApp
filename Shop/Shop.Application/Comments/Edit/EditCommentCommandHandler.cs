using Common.Application;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Categories.Edit
{
    public class EditCommentCommandHandler : IBaseCommandHandler<EditCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public EditCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var Comment = await _repository.GetTracking(request.CommentId);
            if(Comment == null || Comment.UserId != request.UserId)
                return OperationResult.NotFound();

            Comment.Edit(request.Text);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}