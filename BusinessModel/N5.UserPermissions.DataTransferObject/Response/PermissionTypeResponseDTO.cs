using N5.UserPermissions.Common.Model;
using N5.UserPermissions.Common.Model.Interface;
using N5.UserPermissions.Entity;
using System.ComponentModel.DataAnnotations;

namespace N5.UserPermissions.DataTransferObject.Response
{
    public class PermissionTypeResponseDTO : BusinessModelBase, IBusinessDTO<PermissionType>
    {
        [Display(Name = "Descripción", ShortName = "Descripción", Description = "Descripción del Tipo de Permiso")]
        public string Description { get; set; }

        public PermissionTypeResponseDTO()
        {

        }

        public PermissionTypeResponseDTO(PermissionType entity)
        {
            this.Id = entity.Id;
            this.Description = entity.Description;
            this.IsActive = entity.IsActive;
        }

        public PermissionType ToEntity()
        {
            return new PermissionType()
            {
                Id = this.Id,
                Description = this.Description,
                IsActive = this.IsActive,
            };
        }
    }
}
