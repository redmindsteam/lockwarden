using LockWarden.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.DataAccess.Interfaces
{
    public interface IGenericRepository<T>
    {
        public Task<bool> CreateAsync(T entity);

        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id,User user);

        public Task<User> GetUserAsync(int id);
        public Task<List<User>> GetAllUsers();
    }
}
