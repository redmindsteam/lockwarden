using LockWarden.DataAccess.Interfaces.IRepositories;
using LockWarden.DataAccess.Repositories;
using LockWarden.Domain.ViewModels;
using LockWarden.Service.Interfaces;
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
        public Task<(bool IsSuccesful, string Message)> CreateAsync(CardViewModel cardViewModel)
        {
            throw new NotImplementedException();
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
