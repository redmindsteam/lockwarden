using LockWarden.Domain.Models;
using LockWarden.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Service.Interfaces
{
    public interface ILoginService
    {
        Task<(bool IsSuccesful, string Message)> CreateAsync(LoginViewModel loginViewModel,string userpassword);
        Task<(bool IsSuccesful, string Message)> UpdateAsync(LoginViewModel loginViewModel);
        Task<(bool IsSuccesful, string Message)> GetAllAsync(int userid);
        Task<(bool IsSuccesful, string Message)> DeleteAsync(int loginid);

    }
}
