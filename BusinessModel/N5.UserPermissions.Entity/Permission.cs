using N5.UserPermissions.Common.Model;
using N5.UserPermissions.Entity.Base;
using System;

namespace N5.UserPermissions.Entity
{
    public class Permission : PermissionBase
    {
        public PermissionType PermissionType { get; set; }
    }
}
