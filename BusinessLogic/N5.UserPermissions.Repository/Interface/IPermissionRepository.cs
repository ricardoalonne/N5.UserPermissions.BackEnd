using N5.UserPermissions.Common.Repository.IAction;
using N5.UserPermissions.Entity;

namespace N5.UserPermissions.Repository.Interface
{
    public interface IPermissionRepository : IReadRepository<Permission, int>, ICreateRepository<Permission>, IUpdateRepository<Permission>, IRemoveRepository<int>
    {
    }
}
