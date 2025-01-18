using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application.Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit;

internal class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IDomainUserservice _domainService;
    private readonly IFileService _fileService;
    public EditUserCommandHandler(IUserRepository repository, IDomainUserservice domainService, IFileService fileService)
    {
        _repository = repository;
        _domainService = domainService;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var oldAvatar = user.Avatar;
        user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, _domainService);
        if (request.Avatar != null)
        {
            var imageName = await _fileService
                .SaveFileAndGenerateName(request.Avatar, Directories.Avatar);
            user.SetImage(imageName);
        }

        DeleteOldAvatar(request.Avatar, oldAvatar);
        await _repository.Save();
        return OperationResult.Success();
    }

    private void DeleteOldAvatar(IFormFile? avatarFile, string oldImage)
    {
        if (avatarFile == null || oldImage == "avatar.png")
            return;

        _fileService.DeleteFile(Directories.Avatar, oldImage);
    }
}