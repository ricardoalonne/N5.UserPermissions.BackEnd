namespace N5.UserPermissions.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
