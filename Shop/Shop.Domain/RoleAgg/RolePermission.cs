using Common.Domain;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Domain.RoleAgg
{
    public class RolePermission : BaseEntity
    {
        public RolePermission(Permission permission)
        {
            Permission = permission;
        }

        public long RoleId { get; private set; }
        public Permission Permission { get; private set; }
    }
}
