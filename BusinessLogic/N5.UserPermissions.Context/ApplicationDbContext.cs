using Microsoft.EntityFrameworkCore;
using N5.UserPermissions.Entity;

namespace N5.UserPermissions.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
    }
}
