using N5.UserPermissions.Common.Model;
using N5.UserPermissions.Common.Model.Interface;
using N5.UserPermissions.Common.Model.Validation;
using N5.UserPermissions.Entity;
using System.ComponentModel.DataAnnotations;

namespace N5.UserPermissions.DataTransferObject.Request
{
    public class PermissionTypeRequestDTO : BusinessModelBase, IBusinessDTO<PermissionType>, IClone<PermissionTypeRequestDTO>
    {
        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracterer.")]
        [FirstCapitalLetter]
        [Blanks]
        [Display(Name = "Descripción", ShortName = "Descripción", Description = "Descripción del Tipo de Permiso")]
        public string Description { get; set; }

        public PermissionTypeRequestDTO()
        {

        }

        public PermissionTypeRequestDTO(PermissionType entity)
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

        public PermissionTypeRequestDTO Clone(int id)
        {
            return new PermissionTypeRequestDTO()
            {
                Id = id,
                Description = this.Description,
                IsActive = this.IsActive,
            };
        }
    }
}
