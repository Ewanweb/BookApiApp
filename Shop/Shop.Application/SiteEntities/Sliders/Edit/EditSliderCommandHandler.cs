using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application.Utilities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
        private readonly ISliderRepository _repository;
        private readonly IFileService _fileService;

        public EditSliderCommandHandler(ISliderRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _repository.GetTracking(request.Id);

            if (slider == null)
                return OperationResult.NotFound();
            var imageName = slider.ImageName;

            var oldImage = slider.ImageName;

            if (request.ImageFile != null)
                imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.Slider);

            slider.Edit(request.Title, request.Link, imageName);
            await _repository.Save();

            DeleteImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }

        private void DeleteImage(IFormFile? imageFile, string oldImage)
        {
            if (imageFile != null)
                _fileService.DeleteFile(Directories.Slider ,oldImage);
        }
    }
}
