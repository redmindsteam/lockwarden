using LockWarden.Domain.Models;
using LockWarden.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Service.Interfaces
{
    public interface ICardService
    {
        Task<(bool IsSuccesful, string Message)> CreateAsync(CardViewModel cardViewModel, string userpassword);
        Task<(bool IsSuccesful, string Message)> UpdateAsync(CardViewModel cardViewModel, string userpassword,int CardId);
        Task<(List<CardViewModel> cards, string Message)> GetAllAsync(int userid, string userpassword);
        Task<(bool IsSuccesful, string Message)> DeleteAsync(int cardid, string userpassword);
        Task<(CardViewModel card, string Message)> GetAsync(int NoteId, string userpassword);
    }
}
