using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Interfaces;
using LockWarden.DataAccess.Interfaces.IRepositories;
using LockWarden.Domain.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.DataAccess.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly SqliteConnection _sqliteConnection = new(DB_Constants.DB_Path_File);
        public async Task<bool> CreateAsync(Note entity)
        {
            try
            {
                await _sqliteConnection.OpenAsync();
                string query = "insert into notes(Deleted,Id,Header,Content,UserId) " +
                    "values (@Deleted,@Id,@Header,@Content,@UserId);";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
                {
                    Parameters =
                    {
                        new SqliteParameter("Deleted",entity.Deleted),
                        new SqliteParameter("Id",entity.Id),
                        new SqliteParameter("Header",entity.Header),
                        new SqliteParameter("Content",entity.Content),
                        new SqliteParameter("UserId", entity.UserId)
                    }
                };
                var result = await command.ExecuteNonQueryAsync();
                if (result == 0) return false; else return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                await _sqliteConnection.CloseAsync();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {

            try
            {
                await _sqliteConnection.OpenAsync();
                string query = $"delete from notes where id={id};";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
                var result = await command.ExecuteNonQueryAsync();
                if (result == 0) return false; else return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                await _sqliteConnection.CloseAsync();
            }
        }

        public async Task<List<Note>> GetAllAsync()
        {
            try
            {
                await _sqliteConnection.OpenAsync();
                string query = $"select * from notes;";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
                var readly = await command.ExecuteReaderAsync();
                List<Note> notes = new List<Note>();
                while (await readly.ReadAsync())
                {
                    Note note = new Note(readly.GetDateTime(0), readly.GetInt32(1), readly.GetString(2), readly.GetString(3), readly.GetInt32(4));
                    notes.Add(note);
                }
                return notes;

            }
            catch
            {
                return new List<Note>();
            }
            finally
            {
                await _sqliteConnection.CloseAsync();
            }
        }

        public async Task<Note> GetAsync(int id)
        {
            try
            {
                await _sqliteConnection.OpenAsync();
                string query = $"select * from notes where id='{id}';";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
                var readly = await command.ExecuteReaderAsync();
                if (await readly.ReadAsync())
                {
                    Note note = new Note(readly.GetDateTime(0), readly.GetInt32(1), readly.GetString(2), readly.GetString(3), readly.GetInt32(4));
                    return note;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                await _sqliteConnection.CloseAsync();
            }
        }

        public async Task<bool> UpdateAsync(int id, Note entity)
        {

            try
            {
                await _sqliteConnection.OpenAsync();
                string query = "update notes set Deleted=@Deleted, Id=@Id, Header=@Header,Content=@Content,UserId=@UserId;";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
                {
                    Parameters =
                    {
                       new SqliteParameter("Deleted",entity.Deleted),
                        new SqliteParameter("Id",entity.Id),
                        new SqliteParameter("Header",entity.Header),
                        new SqliteParameter("Content",entity.Content),
                        new SqliteParameter("UserId", entity.UserId)
                    }
                };
                var result = await command.ExecuteNonQueryAsync();
                if (result == 0) return false; else return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                await _sqliteConnection.CloseAsync();
            }
        }
    }
}
