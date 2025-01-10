using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application.Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.RemoveImage
{
    internal class RemoveProductImageCommandHandler : IBaseCommandHandler<RemoveProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;
    
        public RemoveProductImageCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = product.RemoveImage(request.ImageId);

            await _repository.Save();
            _fileService.DeleteFile(Directories.ProductGallery, imageName);
            return OperationResult.Success();
        }
    }

}