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

        public async Task<(bool IsSuccesful, string Message)> CreateAsync(LoginViewModel loginViewModel, string userpassword)
        {
            try
            {
                var toseed = Helper.ToSeed(userpassword);
                string password = Crypter.Ciphr(loginViewModel.Password, toseed, Crypt.Encrypt);
                Login login = new Login(DateTime.Now, loginViewModel.Service, loginViewModel.Username, password, loginViewModel.Name, IdentitySingelton.GetInstance().UserId);
                var result = await _repository.Logins.CreateAsync(login);
                if (result)
                {
                    return (true, "Muvafaqqiyatli qo'shildi");
                }
                else
                    return (false, "Ma'lumot qo'shishda xatollik");
            }
            catch
            {
                return (false, "Xatolik");
            }


        }

        public Task<(bool IsSuccesful, string Message)> DeleteAsync(int loginid, string userpassword)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> GetAllAsync(int userid, string userpassword)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> UpdateAsync(LoginViewModel loginViewModel, string userpassword)
        {
            throw new NotImplementedException();
        }
    }
}
