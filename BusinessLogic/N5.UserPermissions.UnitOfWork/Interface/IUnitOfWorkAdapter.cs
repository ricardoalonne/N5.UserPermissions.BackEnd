using System;
using System.Threading.Tasks;

namespace N5.UserPermissions.UnitOfWork.Interface
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repository { get; }
        Task<int> SaveChanges();
    }
}
