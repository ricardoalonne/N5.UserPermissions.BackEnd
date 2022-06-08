using Microsoft.EntityFrameworkCore;
using N5.UserPermissions.Context;
using N5.UserPermissions.Entity;
using N5.UserPermissions.Repository.Base;
using N5.UserPermissions.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N5.UserPermissions.Repository.Implementation
{
    public class PermissionRepository : RepositoryBase, IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Permission permission)
        {
            await _context.AddAsync(permission);
        }

        public async Task<Permission> Get(int id)
        {
            var permission = await _context.Permissions.Include(permission => permission.PermissionType).FirstOrDefaultAsync(permission => permission.Id == id);
            if(permission != null) permission.PermissionType = await _context.PermissionTypes.FindAsync(permission.PermissionType.Id);
            return permission;
        }

        public async Task<IEnumerable<Permission>> Get()
        {
            var permissions = await _context.Permissions.Include(permission => permission.PermissionType).ToListAsync();
            permissions = permissions.Where(permission => permission.IsActive).ToList();

            return permissions;
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            return await _context.Permissions.Include(permission => permission.PermissionType).ToListAsync();
        }

        public async Task Remove(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            permission.IsActive = false;
        }

        public async Task Update(Permission permission)
        {
            var permissionUpdate = await _context.Permissions.FindAsync(permission.Id);
            permissionUpdate.EmployeeName = permission.EmployeeName;
            permissionUpdate.EmployeeLastName = permission.EmployeeLastName;
            permissionUpdate.PermissionType = permission.PermissionType;
            permissionUpdate.PermitDate = permission.PermitDate;
            permissionUpdate.IsActive = true;

        }
    }
}
