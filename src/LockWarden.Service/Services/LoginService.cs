using LockWarden.DataAccess.Interfaces.IRepositories;
using LockWarden.DataAccess.Repositories;
using LockWarden.Domain.Models;
using LockWarden.Domain.ViewModels;
using LockWarden.Service.Commons;
using LockWarden.Service.Interfaces;
using LockWarden.Service.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly Repository _repository;
        public LoginService()
        {
            _repository = new Repository();
        }

        public Task<(bool IsSuccesful, string Message)> CreateAsync(LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> DeleteAsync(int loginid)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> GetAllAsync(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> UpdateAsync(LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
