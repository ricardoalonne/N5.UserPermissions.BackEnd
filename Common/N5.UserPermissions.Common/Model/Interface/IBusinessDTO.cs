namespace N5.UserPermissions.Common.Model.Interface
{
    public interface IBusinessDTO<TEntity> where TEntity : class
    {
        public TEntity ToEntity();
    }
}
