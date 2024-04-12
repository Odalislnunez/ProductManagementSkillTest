namespace ProductManagement.Core.Services.Interfaces
{
    public interface IGeneridCrudExt2Service<T> : IGeneridCrudExtService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll(int idfrom, int idto);
    }

}
