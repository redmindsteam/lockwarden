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
    public class CardService : ICardService
    {
        private readonly Repository _repository;
        public CardService()
        {
            _repository = new Repository();
        }
        public async Task<(bool IsSuccesful, string Message)> CreateAsync(CardViewModel cardViewModel, string userpassword)
        {
            try
            {
                var toseed = Helper.ToSeed(userpassword);
                string password = Crypter.Ciphr(cardViewModel.Pin, toseed, Crypt.Encrypt);
                Card card = new Card(DateTime.Now, cardViewModel.Bank, cardViewModel.Number, password, cardViewModel.Name, IdentitySingelton.GetInstance().UserId);
                var result = await _repository.Cards.CreateAsync(card);
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

        public Task<(bool IsSuccesful, string Message)> DeleteAsync(int cardid)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> GetAllAsync(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> UpdateAsync(CardViewModel cardViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
