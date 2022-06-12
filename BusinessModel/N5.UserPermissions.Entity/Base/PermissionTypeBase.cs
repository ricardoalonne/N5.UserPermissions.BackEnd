using N5.UserPermissions.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.UserPermissions.Entity.Base
{
    public abstract class PermissionTypeBase : BusinessModelBase
    {
        public string Description { get; set; }
    }
}
