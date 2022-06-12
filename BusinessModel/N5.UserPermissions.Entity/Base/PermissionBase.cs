using N5.UserPermissions.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.UserPermissions.Entity.Base
{
    public abstract class PermissionBase : BusinessModelBase
    {
        public string EmployeeName { get; set; }

        public string EmployeeLastName { get; set; }

        public int PermissionTypeId { get; set; }

        public DateTime PermitDate { get; set; } = DateTime.UtcNow;
    }
}
