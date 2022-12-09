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
        Task<(bool IsSuccesful, string Message)> UpdateAsync(LoginViewModel loginViewModel, string userpassword,int loginid);
        Task<(List<LoginViewModel> loginView, string Message)> GetAllAsync(int userid, string userpassword);
        Task<(LoginViewModel loginView, string Message)> GetAsync(int userid, string userpassword);
        Task<(bool IsSuccesful, string Message)> DeleteAsync(int loginid, string userpassword);

    }
}
