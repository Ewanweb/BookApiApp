using Common.Application;
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.ChangeStatus
{
    public class ChangeCommentStatusCommandHandler : IBaseCommandHandler<ChangeCommentStatusCommand>
    {
        ICommentRepository _repository;

        public ChangeCommentStatusCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
        {
            var Comment = await _repository.GetTracking(request.Id);
            if (Comment == null)
                return OperationResult.NotFound();

            Comment.ChangeStatus(request.Status);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}