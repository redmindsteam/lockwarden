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
                string username= Crypter.Ciphr(loginViewModel.Username, toseed, Crypt.Encrypt);
                Login login = new Login(DateTime.Now, loginViewModel.Service, username, password, loginViewModel.Name, IdentitySingelton.GetInstance().UserId);
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

        public async  Task<(bool IsSuccesful, string Message)> DeleteAsync(int loginid, string userpassword)
        {
            try
            {
                await _repository.Logins.DeleteAsync(loginid);
                return (true, "Successful");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }


        public async Task<(LoginViewModel loginView, string Message)> GetAsync(int loginid, string userpassword)
        {
            try
            {
                var login = await _repository.Logins.GetAsync(loginid);
                string password = Crypter.Ciphr(login.Password, Helper.ToSeed(userpassword), Crypt.Decrypt);
                string username = Crypter.Ciphr(login.Username, Helper.ToSeed(userpassword), Crypt.Decrypt);
                LoginViewModel loginViewModel = new LoginViewModel(login.Service, username, password, login.Name);
                loginViewModel.Id = login.Id;

                return (loginViewModel, "Succesful");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(bool IsSuccesful, string Message)> UpdateAsync(LoginViewModel loginViewModel, string userpassword,int loginid)
        {
            try
            {
                await _repository.Logins.DeleteAsync(loginid);
                await CreateAsync(loginViewModel, userpassword);
                return (true, "Successful");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(List<LoginViewModel> loginView, string Message)> GetAllAsync(int userid, string userpassword)
        {
            try
            {
                var loginviewmodels = new List<LoginViewModel>();
                var logins = await _repository.Logins.GetAllAsync();
                var userlogins = logins.Where(x => x.UserId == IdentitySingelton.GetInstance().UserId);
                foreach (var login in userlogins)
                {

                    string password = Crypter.Ciphr(login.Password, Helper.ToSeed(userpassword), Crypt.Decrypt);
                    string username = Crypter.Ciphr(login.Username, Helper.ToSeed(userpassword), Crypt.Decrypt);
                    LoginViewModel loginViewModel = new LoginViewModel(login.Service, username, password, login.Name);
                    loginViewModel.Id = login.Id;
                    loginviewmodels.Add(loginViewModel);
                }

                return (loginviewmodels, "Succesful");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
