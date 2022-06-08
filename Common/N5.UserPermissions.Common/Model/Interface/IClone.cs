namespace N5.UserPermissions.Common.Model.Interface
{
    public interface IClone<TModel> where TModel : class
    {
        public TModel Clone(int id);
    }
}
