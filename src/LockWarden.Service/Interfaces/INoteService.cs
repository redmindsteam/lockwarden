using LockWarden.Domain.Models;
using LockWarden.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Service.Interfaces
{
    public interface INoteService
    {
        Task<(bool IsSuccesful, string Message)> CreateAsync(NoteViewModel noteViewModel, string userpassword);
        Task<(bool IsSuccesful, string Message)> UpdateAsync(NoteViewModel noteViewModel, string userpassword);
        Task<(bool IsSuccesful, string Message)> GetAllAsync(int userid, string userpassword);
        Task<(bool IsSuccesful, string Message)> DeleteAsync(int noteid, string userpassword);
    }
}
