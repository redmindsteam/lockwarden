using LockWarden.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Service.Interfaces
{
    public interface IUserService
    {
        Task<(bool IsSuccesful, string Message)> RegistrationAsync(UserViewModel userCreateViewModel);

        Task<(bool IsSuccesful, string Message)> LoginAsync(string login, string password);
    }
}
