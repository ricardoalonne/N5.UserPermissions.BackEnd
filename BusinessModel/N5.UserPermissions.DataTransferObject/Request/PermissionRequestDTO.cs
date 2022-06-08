using N5.UserPermissions.Common.Model;
using N5.UserPermissions.Common.Model.Interface;
using N5.UserPermissions.Common.Model.Validation;
using N5.UserPermissions.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace N5.UserPermissions.DataTransferObject.Request
{
    public class PermissionRequestDTO : BusinessModelBase, IBusinessDTO<Permission>, IClone<PermissionRequestDTO>
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracterer.")]
        [FirstCapitalLetters]
        [Blanks]
        [Display(Name = "Nombre del Empleado", ShortName = "Nombre", Description = "Nombre del Empleado")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caracterer.")]
        [FirstCapitalLetters]
        [Blanks]
        [Display(Name = "Apellido del Empleado", ShortName = "Apellido", Description = "Apellido del Empleado")]
        public string EmployeeLastName { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Permiso es obligatorio.")]
        [Display(Name = "Tipo de Permiso", ShortName = "Tipo", Description = "Tipo de Permiso")]
        public int PermissionTypeId { get; set; }

        [Required(ErrorMessage = "El campo Fecha del Permiso es obligatorio.")]
        [Display(Name = "Fecha del Permiso", ShortName = "Fecha del Permiso", Description = "Fecha del Permiso al Empleado")]
        public DateTime PermitDate { get; set; } = DateTime.UtcNow;

        public PermissionRequestDTO()
        {

        }

        public PermissionRequestDTO(Permission entity)
        {
            this.Id = entity.Id;
            this.EmployeeName = entity.EmployeeName;
            this.EmployeeLastName = entity.EmployeeLastName;
            this.PermissionTypeId = entity.PermissionType.Id;
            this.PermitDate = entity.PermitDate;
            this.IsActive = entity.IsActive;
        }

        public Permission ToEntity()
        {
            return new Permission()
            {
                Id = this.Id,
                EmployeeName = this.EmployeeName,
                EmployeeLastName = this.EmployeeLastName,
                PermissionType = new PermissionType() { Id = this.PermissionTypeId },
                PermitDate = this.PermitDate,
                IsActive = this.IsActive,
            };
        }

        public PermissionRequestDTO Clone(int id)
        {
            return new PermissionRequestDTO()
            {
                Id = id,
                EmployeeName = this.EmployeeName,
                EmployeeLastName = this.EmployeeLastName,
                PermissionTypeId = this.PermissionTypeId,
                PermitDate = this.PermitDate,
                IsActive = this.IsActive,
            };
        }
    }
}
