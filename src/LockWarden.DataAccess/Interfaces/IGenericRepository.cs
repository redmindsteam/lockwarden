using LockWarden.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.DataAccess.Interfaces
{
    public interface IGenericRepository<T>where T:IReferenceable
    {
        public Task<bool> CreateAsync(T entity);

        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id,T entity);
        public Task<T> GetAsync(int id);
        public Task<List<T>> GetAllAsync(); 
    }
}
