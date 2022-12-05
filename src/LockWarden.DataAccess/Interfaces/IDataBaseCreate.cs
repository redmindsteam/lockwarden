using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.DataAccess.Interfaces
{
    public interface IDataBaseCreate
    {
        Task<bool> CreateDataBaseAsync();
    }
}
