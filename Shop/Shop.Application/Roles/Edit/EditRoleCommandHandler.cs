using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Edit
{
    public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public EditRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetTracking(request.Id);
            if (role == null)
                return OperationResult.NotFound();

            role.Edit(request.Title);

            var permission = new List<RolePermission>();

            request.Permissions.ForEach(f =>
            {
                permission.Add(new RolePermission(f));
            });
            role.SetPermission(permission);

            await _roleRepository.Save();
            return OperationResult.Success();
        }
    }
}
