using N5.UserPermissions.DataTransferObject.Request;
using N5.UserPermissions.DataTransferObject.Response;
using N5.UserPermissions.Service.Interface;
using N5.UserPermissions.UnitOfWork.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N5.UserPermissions.Service.Implementation
{
    public class PermissionService : IPermissionService
    {
        private IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PermissionResponseDTO>> GetAll()
        {
            using (var connection = _unitOfWork.Create())
            {
                var permissionsEntity = await connection.Repository.IPermissionRepository.GetAll();
                var permissions = permissionsEntity.Select(permission => new PermissionResponseDTO(permission)).ToList();
                return permissions;
            }
        }

        public async Task<List<PermissionResponseDTO>> Get()
        {
            using (var connection = _unitOfWork.Create())
            {
                var permissionsEntity = await connection.Repository.IPermissionRepository.Get();
                var permissions = permissionsEntity.Select(permission => new PermissionResponseDTO(permission)).ToList();
                return permissions;
            }
        }

        public async Task<PermissionResponseDTO> Get(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                var permissionEntity = await connection.Repository.IPermissionRepository.Get(id);
                return new PermissionResponseDTO(permissionEntity);
            }
        }

        public async Task<bool> Post(PermissionRequestDTO requestModel)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IPermissionRepository.Create(requestModel.ToEntity());
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Put(PermissionRequestDTO requestModel)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IPermissionRepository.Update(requestModel.ToEntity());
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IPermissionRepository.Remove(id);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

    }
}
