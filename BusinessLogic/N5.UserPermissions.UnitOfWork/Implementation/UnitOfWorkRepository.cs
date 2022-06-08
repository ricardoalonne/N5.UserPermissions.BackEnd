
using N5.UserPermissions.Context;
using N5.UserPermissions.Repository.Implementation;
using N5.UserPermissions.Repository.Interface;
using N5.UserPermissions.UnitOfWork.Interface;

namespace N5.UserPermissions.UnitOfWork.Implementation
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IPermissionRepository IPermissionRepository { get; }
        public IPermissionTypeRepository IPermissionTypeRepository { get; }

        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            IPermissionRepository = new PermissionRepository(context);
            IPermissionTypeRepository = new PermissionTypeRepository(context);
        }

    }
}
