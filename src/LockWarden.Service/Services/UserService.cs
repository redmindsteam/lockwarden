using LockWarden.DataAccess.Interfaces.IRepositories;
using LockWarden.DataAccess.Repositories;
using LockWarden.Domain.Models;
using LockWarden.Domain.ViewModels;
using LockWarden.Service.Commons;
using LockWarden.Service.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Service.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        public UserService()
        {
            _repository = new UserRepository();
        }

        public async Task<(bool IsSuccesful, string Message)> LoginAsync(string login, string password)
        {
            var user = await _repository.FindByLoginAsync(login);
            if (user is null) return (IsSuccessful: false, Message: "Noto");
            var hashResult = Crypter.Verify(password, user.PasswordHash, user.Salt);
            if (hashResult)
            {
                IdentitySingelton.BuildInstance(user.Id);
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
    }
}
        