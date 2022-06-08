using N5.UserPermissions.Common.Repository.IAction;
using N5.UserPermissions.Entity;

namespace N5.UserPermissions.Repository.Interface
{
    public interface IPermissionTypeRepository : IReadRepository<PermissionType, int>, ICreateRepository<PermissionType>, IUpdateRepository<PermissionType>, IRemoveRepository<int>
    {
    }
}
