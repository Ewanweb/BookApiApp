using Common.Application;
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.Create
{
    public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
    {
        ICommentRepository _repository;

        public CreateCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var Comment = new Comment(request.UserId, request.ProductId, request.Text);
            await _repository.AddAsync(Comment);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}