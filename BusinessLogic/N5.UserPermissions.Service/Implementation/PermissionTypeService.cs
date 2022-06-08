using N5.UserPermissions.DataTransferObject.Request;
using N5.UserPermissions.DataTransferObject.Response;
using N5.UserPermissions.Service.Interface;
using N5.UserPermissions.UnitOfWork.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N5.UserPermissions.Service.Implementation
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private IUnitOfWork _unitOfWork;

        public PermissionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PermissionTypeResponseDTO>> GetAll()
        {
            using (var connection = _unitOfWork.Create())
            {
                var permissionTypesEntity = await connection.Repository.IPermissionTypeRepository.GetAll();
                var permissionTypes = permissionTypesEntity.Select(permissionType => new PermissionTypeResponseDTO(permissionType)).ToList();
                return permissionTypes;
            }
        }

        public async Task<List<PermissionTypeResponseDTO>> Get()
        {
            using (var connection = _unitOfWork.Create())
            {
                var permissionTypesEntity = await connection.Repository.IPermissionTypeRepository.Get();
                var permissionTypes = permissionTypesEntity.Select(permissionType => new PermissionTypeResponseDTO(permissionType)).ToList();
                return permissionTypes;
            }
        }

        public async Task<PermissionTypeResponseDTO> Get(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                var permissionTypeEntity = await connection.Repository.IPermissionTypeRepository.Get(id);
                return new PermissionTypeResponseDTO(permissionTypeEntity);
            }
        }

        public async Task<bool> Post(PermissionTypeRequestDTO requestModel)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IPermissionTypeRepository.Create(requestModel.ToEntity());
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Put(PermissionTypeRequestDTO requestModel)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IPermissionTypeRepository.Update(requestModel.ToEntity());
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _unitOfWork.Create())
            {
                await connection.Repository.IPermissionTypeRepository.Remove(id);
                var result = await connection.SaveChanges();
                return result > 0;
            }
        }

    }
}
