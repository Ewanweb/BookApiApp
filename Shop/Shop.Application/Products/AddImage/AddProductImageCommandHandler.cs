using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application.Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.AddImage
{
    internal class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;
    
        public AddProductImageCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductGallery);
            var productImage = new ProductImage(imageName, request.Sequence);

            product.AddImage(productImage);

            await _repository.Save();
            return OperationResult.Success();
        }
    }

}