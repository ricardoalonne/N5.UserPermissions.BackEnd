using System.Threading.Tasks;

namespace N5.UserPermissions.Common.Repository.IAction
{
    public interface IUpdateRepository<T> where T : class
    {
        Task Update(T t);
    }
}
