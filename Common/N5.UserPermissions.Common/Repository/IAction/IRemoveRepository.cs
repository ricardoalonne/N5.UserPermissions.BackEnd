using System.Threading.Tasks;

namespace N5.UserPermissions.Common.Repository.IAction
{
    public interface IRemoveRepository<T>
    {
        Task Remove(T id);
    }
}
