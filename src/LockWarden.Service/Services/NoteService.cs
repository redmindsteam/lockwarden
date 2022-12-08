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
     public class NoteService:INoteService
    {
        private readonly Repository _repository;
        public NoteService()
        {
            _repository = new Repository();
        }

        public Task<(bool IsSuccesful, string Message)> CreateAsync(NoteViewModel noteViewModel, string userpassword)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> DeleteAsync(int noteid, string userpassword)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> GetAllAsync(int userid, string userpassword)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> UpdateAsync(NoteViewModel noteViewModel, string userpassword)
        {
            throw new NotImplementedException();
        }
    }
}
