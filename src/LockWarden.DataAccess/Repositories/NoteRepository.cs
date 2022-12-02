using LockWarden.DataAccess.Interfaces;
using LockWarden.DataAccess.Interfaces.IRepositories;
using LockWarden.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.DataAccess.Repositories
{
    internal class NoteRepository : INoteRepository
    {
        public Task<bool> CreateAsync(Note entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Note>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Note> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Note entity)
        {
            throw new NotImplementedException();
        }
    }
}
