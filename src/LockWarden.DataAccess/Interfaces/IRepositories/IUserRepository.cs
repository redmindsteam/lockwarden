using LockWarden.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.DataAccess.Interfaces.IRepositories
{

    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> FindByLoginAsync(string login);
    }
}
