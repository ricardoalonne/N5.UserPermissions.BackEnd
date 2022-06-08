using N5.UserPermissions.Repository.Interface;

namespace N5.UserPermissions.UnitOfWork.Interface
{
    public interface IUnitOfWorkRepository
    {
        IPermissionRepository IPermissionRepository { get; }
        IPermissionTypeRepository IPermissionTypeRepository { get; }
    }
}
