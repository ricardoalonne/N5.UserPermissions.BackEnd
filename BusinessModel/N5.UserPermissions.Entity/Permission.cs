using N5.UserPermissions.Common.Model;
using System;

namespace N5.UserPermissions.Entity
{
    public class Permission : BusinessModelBase
    {
        public string EmployeeName { get; set; }

        public string EmployeeLastName { get; set; }

        public PermissionType PermissionType { get; set; }

        public DateTime PermitDate { get; set; } = DateTime.UtcNow;
    }
}
