using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Create
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
            var permission = new List<RolePermission>();
            request.Permissions.ForEach(f =>
            {
                permission.Add(new RolePermission(f));
            });
            var role = new Role(request.Title, permission);
            await _roleRepository.AddAsync(role);
            await _roleRepository.Save();
            return OperationResult.Success();
        }
    }
}
