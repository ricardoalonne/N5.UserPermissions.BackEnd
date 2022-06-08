using N5.UserPermissions.Context;
using N5.UserPermissions.UnitOfWork.Interface;

namespace N5.UserPermissions.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkAdapter(_context);
        }
    }
}
