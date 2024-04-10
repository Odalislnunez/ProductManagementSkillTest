namespace ProductManagement.Core.Services.Interfaces
{
    public interface IGeneridCrudExtService<T> : IGeneridCrudService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllById(int id);
    }

}
