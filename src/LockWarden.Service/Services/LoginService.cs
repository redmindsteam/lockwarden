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
    public class LoginService:ILoginService
    {
        private readonly Repository _repository;
        public LoginService()
        {
            _repository = new Repository();
        }

        public Task<(bool IsSuccesful, string Message)> CreateAsync(UserViewModel userCreateViewModel)
        {
            throw new NotImplementedException();
        }

        //public async Task<(bool IsSuccesful, string Message)> CreateAsync(UserViewModel userCreateViewModel)
        //{
        //    var user= await _repository.Users.GetAsync(IdentitySingelton.GetInstance().UserId);
        //    var seed=Helper.ToSeed(user.PasswordHash)
        //}
    }
}
