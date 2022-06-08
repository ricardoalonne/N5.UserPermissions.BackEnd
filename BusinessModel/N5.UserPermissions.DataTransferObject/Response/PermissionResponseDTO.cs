using N5.UserPermissions.Common.Model;
using N5.UserPermissions.Common.Model.Interface;
using N5.UserPermissions.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace N5.UserPermissions.DataTransferObject.Response
{
    public class PermissionResponseDTO : BusinessModelBase, IBusinessDTO<Permission>
    {
        [Display(Name = "Nombre del Empleado", ShortName = "Nombre", Description = "Nombre del Empleado")]
        public string EmployeeName { get; set; }

        [Display(Name = "Apellido del Empleado", ShortName = "Apellido", Description = "Apellido del Empleado")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Tipo de Permiso", ShortName = "Tipo", Description = "Tipo de Permiso")]
        public PermissionTypeResponseDTO PermissionType { get; set; }

        [Display(Name = "Fecha del Permiso", ShortName = "Fecha del Permiso", Description = "Fecha del Permiso al Empleado")]
        public DateTime PermitDate { get; set; } = DateTime.UtcNow;

        public PermissionResponseDTO()
        {

        }

        public PermissionResponseDTO(Permission entity)
        {
            this.Id = entity.Id;
            this.EmployeeName = entity.EmployeeName;
            this.EmployeeLastName = entity.EmployeeLastName;
            this.PermissionType = new PermissionTypeResponseDTO(entity.PermissionType);
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
                PermissionType = this.PermissionType.ToEntity(),
                PermitDate = this.PermitDate,
                IsActive = this.IsActive,
            };
        }
    }
}
