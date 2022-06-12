using N5.UserPermissions.Context;
using N5.UserPermissions.UnitOfWork.Interface;
using System.Threading.Tasks;

namespace N5.UserPermissions.UnitOfWork.Implementation
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        private readonly ApplicationDbContext _context;

        public IUnitOfWorkRepository Repository { get; set; }

        public UnitOfWorkAdapter(ApplicationDbContext context)
        {
            _context = context;

            Repository = new UnitOfWorkRepository(context);
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
