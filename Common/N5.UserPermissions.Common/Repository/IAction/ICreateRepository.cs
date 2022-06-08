using System.Threading.Tasks;

namespace N5.UserPermissions.Common.Repository.IAction
{
    public interface ICreateRepository<T> where T : class
    {
        Task Create(T t);
    }
}
