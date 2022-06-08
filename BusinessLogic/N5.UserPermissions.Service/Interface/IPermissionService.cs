using N5.UserPermissions.Common.Service;
using N5.UserPermissions.DataTransferObject.Request;
using N5.UserPermissions.DataTransferObject.Response;

namespace N5.UserPermissions.Service.Interface
{
    public interface IPermissionService : IService<PermissionResponseDTO, PermissionRequestDTO>
    {
    }
}
