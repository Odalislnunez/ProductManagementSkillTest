﻿namespace ProductManagement.Core.Services.Interfaces
{
    public interface IGeneridCrudService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<bool> Create(T dto);
        public Task<bool> Update(int id, T dto);
        public Task<bool> Delete(int id);
        public Task<bool> ChangeStatus(int id);
    }
}
