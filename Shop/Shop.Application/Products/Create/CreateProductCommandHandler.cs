using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application.Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Create
{
    internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductDomainService _domainService;
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;
    
        public CreateProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
        {
            _domainService = domainService;
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);

            var product = new Product(request.Title, request.Description, request.CategoryId, request.SubCategoryId, request.SecondorySubCategoryId,
            _domainService, request.Slug, request.SeoData );
            
            await _repository.AddAsync(product);

            var specifications = new List<ProductSpecification>();

            request.Specification.ToList().ForEach(specification => 

                specifications.Add(new ProductSpecification(specification.Key, specification.Value))

            );

            product.SetSpecification(specifications);
            await _repository.Save();
            return OperationResult.Success();
        }
    }

}