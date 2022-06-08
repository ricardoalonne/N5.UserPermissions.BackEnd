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
    public class PermissionTypeRepository : RepositoryBase, IPermissionTypeRepository
    {
        public PermissionTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(PermissionType permissionType)
        {
            await _context.AddAsync(permissionType);
        }

        public async Task<PermissionType> Get(int id)
        {
            return await _context.PermissionTypes.FindAsync(id);
        }

        public async Task<IEnumerable<PermissionType>> Get()
        {
            var permissionTypes = await _context.PermissionTypes.ToListAsync();
            permissionTypes = permissionTypes.Where(permissionType => permissionType.IsActive).ToList();

            return permissionTypes;
        }

        public async Task<IEnumerable<PermissionType>> GetAll()
        {
            return await _context.PermissionTypes.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var permissionType = await _context.PermissionTypes.FindAsync(id);
            permissionType.IsActive = false;
        }

        public async Task Update(PermissionType permissionType)
        {
            var permissionTypeUpdate = await _context.PermissionTypes.FindAsync(permissionType.Id);
            permissionTypeUpdate.Description = permissionType.Description;
            permissionTypeUpdate.IsActive = true;

        }
    }
}
