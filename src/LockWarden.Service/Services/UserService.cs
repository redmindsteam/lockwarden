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
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;
        public UserService()
        {
            _repository = new UserRepository();
        }

        public async Task<(bool IsSuccesful, string Message)> LoginAsync(string login, string password)
        {
            var user = await _repository.FindByLoginAsync(login);
            if (user is null) return (IsSuccessful: false, Message: "Noto'g'ri login kritildi");
            var hashResult = Crypter.Verify(user.PasswordHash, password, user.Salt);
            if (hashResult)
            {
                IdentitySingelton.BuildInstance(user.Id);
                return (IsSuccessful: true, Message: "");
            }

            else return (IsSuccessful: false, Message: "Notug'ri parol kritildi!");
        }
        public async Task<(bool IsSuccesful, string Message)> LoginUpdateAsync(string login, string password)
        {
            var user = await _repository.FindByLoginAsync(login);
            if (user is null) return (IsSuccessful: false, Message: "Noto'g'ri login  kiritildi");
            var hashResult = Crypter.Verify(user.PasswordHash, password, user.Salt);
            if (hashResult)
            {
                return (IsSuccessful: true, Message: "");
            }

            else return (IsSuccessful: false, Message: "Notug'ri parol kritildi!");
        }

        public async Task<(bool IsSuccesful, string Message)> RegistrationAsync(UserViewModel userCreateViewModel)
        {
            var hashresult = Crypter.Hash(userCreateViewModel.Password);
            User user = new User(userCreateViewModel.Name, userCreateViewModel.Login, hashresult.hash, hashresult.salt);
            var result = await _repository.CreateAsync(user);
            if (result) return (IsSuccessful: true, Message: "Muvaffaqiyatli");
            else return (IsSuccesful: false, Message: "Bu login hozirgi vaqtda band");
        }
        public async Task<(bool IsSuccesful, string Message)> UpdateAsync(UserViewModel userUpdateViewModel)

        {
            var hashresult = Crypter.Hash(userUpdateViewModel.Password);
            User user = new User(userUpdateViewModel.Name, userUpdateViewModel.Login, hashresult.hash, hashresult.salt);
            var result =await _repository.UpdateAsync(IdentitySingelton.GetInstance().UserId, user);
            if (result) return (IsSuccessful: true, Message: "Muvaffaqiyatli");
            else return (IsSuccesful: false, Message: "Malumot qo'shishda xatolik");

        }
    }
}
        