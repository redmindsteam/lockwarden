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
				string query = "insert into notes(deleted,header,content,user_id) " +
					"values (@deleted,@header,@content,@user_id);";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
				{
					Parameters =
					{
						new SqliteParameter("deleted",entity.Deleted),
						new SqliteParameter("header",entity.Header),
						new SqliteParameter("content",entity.Content),
						new SqliteParameter("user_id", entity.UserId)
					}
				};
				var result = await command.ExecuteNonQueryAsync();
				if(result == 0)
					return false;
				else
					return true;

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
				if(result == 0)
					return false;
				else
					return true;

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
				while(await readly.ReadAsync())
				{
					Note note = new Note(readly.GetInt32(0), readly.GetDateTime(1), readly.GetString(2), readly.GetString(3), readly.GetInt32(4));
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
				string query = $"select * from notes where id={id};";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var readly = await command.ExecuteReaderAsync();
				if(await readly.ReadAsync())
				{
					Note note = new Note(readly.GetInt32(0), readly.GetDateTime(1), readly.GetString(2), readly.GetString(3), readly.GetInt32(4));
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
				string query = $"update notes set  header=@header,content=@content,user_id=@user_id where id={id};";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
				{
					Parameters =
					{
					   new SqliteParameter("deleted",entity.Deleted),
						new SqliteParameter("header",entity.Header),
						new SqliteParameter("content",entity.Content),
						new SqliteParameter("user_id", entity.UserId)
					}
				};
				var result = await command.ExecuteNonQueryAsync();
				if(result == 0)
					return false;
				else
					return true;

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
		public async Task<bool> DeleteAllAsync(int userId)
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = $"delete from notes where user_id={userId};";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var result = await command.ExecuteNonQueryAsync();
				if(result == 0)
					return false;
				else
					return true;

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
		public async Task<bool> AddAllAsync(List<Note> entities)
		{
			try
			{

				await _sqliteConnection.OpenAsync();
				string query = "insert into logins(deleted,header,content,user_id) values";
				for(int i = 0; i < entities.Count; i++)
				{
					query += $" (@deleted{i},@header{i},@content{i},@user_id{i}),";
				}
				query = query.TrimEnd(',');
				query += ";";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				for(int i = 0; i < entities.Count; i++)
				{
					command.Parameters.Add(new($"deleted{i}", entities[i].Deleted));
					command.Parameters.Add(new($"user_id{i}", entities[i].UserId));
					command.Parameters.Add(new($"header{i}", entities[i].Header));
					command.Parameters.Add(new($"content{i}", entities[i].Content));
				}
				var result = await command.ExecuteNonQueryAsync();
				if(result == 0)
					return false;
				else
					return true;

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
		public async Task<bool> DeleteAllAsync()
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = $"delete from cards;";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var result = await command.ExecuteNonQueryAsync();
				if(result == 0)
					return false;
				else
					return true;

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
		public async Task<bool> DeleteOldAsync()
		{
			try
			{
				var cards = (await GetAllAsync()).Where(x => !IsOld(x)).ToList();
				await DeleteAllAsync();
				await AddAllAsync(cards);
				return true;
			}
			catch
			{
				return false;
			}
		}
		private bool IsOld(IUsable entity)
		{
			if(entity.Deleted == null)
				return false;
			if((DateTime.Now - entity.Deleted).Value.TotalDays < 7)
				return false;
			return true;
		}
	}
}
