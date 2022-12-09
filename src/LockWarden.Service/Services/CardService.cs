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
using static System.Net.Mime.MediaTypeNames;

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
                string number = Crypter.Ciphr(cardViewModel.Number, toseed, Crypt.Encrypt);
                Card card = new Card(DateTime.Now, cardViewModel.Bank, number, password, cardViewModel.Name, IdentitySingelton.GetInstance().UserId);
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
        public async Task<(bool IsSuccesful, string Message)> DeleteAsync(int CardId, string userpassword)
        {
            try
            {
                await _repository.Cards.DeleteAsync(CardId);
                return (true, "Successful");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(CardViewModel card, string Message)> GetAsync(int CardId, string userpassword)
        {
            try
            {
                var card = await _repository.Cards.GetAsync(CardId);
                string password = Crypter.Ciphr(card.Pin, Helper.ToSeed(userpassword), Crypt.Decrypt);
                string number = Crypter.Ciphr(card.Number, Helper.ToSeed(userpassword), Crypt.Decrypt);
                CardViewModel cardViewModel = new CardViewModel(card.Bank, number, password, card.Name);
                cardViewModel.Id = card.Id;

                return (cardViewModel, "Succesful");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(bool IsSuccesful, string Message)> UpdateAsync(CardViewModel cardViewModel, string userpassword,int CardId)
        {
            try
            {
                await _repository.Cards.DeleteAsync(CardId);
                await CreateAsync(cardViewModel, userpassword);
                return (true, "Successful");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(List<CardViewModel> cards, string Message)> GetAllAsync(int userid, string userpassword)
        {
            try
            {
                var cardviewmodels = new List<CardViewModel>();
                var cards = await _repository.Cards.GetAllAsync();
                var usercards = cards.Where(x => x.UserId == IdentitySingelton.GetInstance().UserId);
                foreach (var usercard in usercards)
                {
                    string password = Crypter.Ciphr(usercard.Pin, Helper.ToSeed(userpassword), Crypt.Decrypt);
                    string number = Crypter.Ciphr(usercard.Number, Helper.ToSeed(userpassword), Crypt.Decrypt);
                    CardViewModel cardViewModel = new CardViewModel(usercard.Bank, number, password, usercard.Name);
                    cardViewModel.Id = usercard.Id;
                    cardviewmodels.Add(cardViewModel);
                }

                return (cardviewmodels, "Succesful");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}
