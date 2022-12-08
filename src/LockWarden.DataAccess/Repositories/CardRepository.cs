using LockWarden.DataAccess.Constants;
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
	public class CardRepository : ICardRepository
	{
		private readonly SqliteConnection _sqliteConnection = new(DB_Constants.DB_Path_File);
		public async Task<bool> CreateAsync(Card entity)
		{

			try
			{
				await _sqliteConnection.OpenAsync();
				string query = "insert into cards(deleted,bank,number,pin,name,user_id) " +
					"values (@deleted,@bank,@number,@pin,@name,@user_id);";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
				{
					Parameters =
						{
							new SqliteParameter("deleted",entity.Deleted),
							new SqliteParameter("user_id",entity.UserId),
							new SqliteParameter("bank",entity.Bank),
							new SqliteParameter("number",entity.Number),
							new SqliteParameter("pin",entity.Pin),
							new SqliteParameter("name",entity.Name)
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
				string query = $"delete from cards where id={id};";
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

		public async Task<List<Card>> GetAllAsync()
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = $"select * from cards;";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var readly = await command.ExecuteReaderAsync();
				List<Card> cards = new List<Card>();
				while(await readly.ReadAsync())
				{
					Card card = new Card(readly.GetInt32(0), readly.GetDateTime(1), readly.GetString(2), readly.GetString(3), readly.GetString(4), readly.GetString(5), readly.GetInt32(6));
					cards.Add(card);
				}
				return cards;

			}
			catch
			{
				return new List<Card>();
			}
			finally
			{
				await _sqliteConnection.CloseAsync();
			}
		}

		public async Task<Card> GetAsync(int id)
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = $"select * from cards where id={id};";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var readly = await command.ExecuteReaderAsync();
				if(await readly.ReadAsync())
				{
					Card card = new Card(readly.GetInt32(0), readly.GetDateTime(1), readly.GetString(2), readly.GetString(3), readly.GetString(4), readly.GetString(5), readly.GetInt32(6));
					return card;
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

		public async Task<bool> UpdateAsync(int id, Card entity)
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = $"update cards set deleted=@deleted, bank=@bank, number=@number, pin=@pin, name=@name where id={id}";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
				{
					Parameters =
						{
							new SqliteParameter("deleted",entity.Deleted),
							new SqliteParameter("bank",entity.Bank),
							new SqliteParameter("number",entity.Number),
							new SqliteParameter("pin",entity.Pin),
							new SqliteParameter("name",entity.Name)
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
				string query = $"delete from cards where user_id={userId};";
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
		public async Task<bool> AddAllAsync(List<Card> entities)
		{
			try
			{

				await _sqliteConnection.OpenAsync();
				string query = "insert into cards(deleted,bank,number,pin,name,user_id) values";
				for(int i = 0; i < entities.Count; i++)
				{
					query += $" (@deleted{i},@bank{i},@number{i},@pin{i},@name{i},@user_id{i}),";
				}
				query = query.TrimEnd(',');
				query += ";";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				for(int i = 0; i < entities.Count; i++)
				{
					command.Parameters.Add(new($"deleted{i}", entities[i].Deleted));
					command.Parameters.Add(new($"user_id{i}", entities[i].UserId));
					command.Parameters.Add(new($"bank{i}", entities[i].Bank));
					command.Parameters.Add(new($"number{i}", entities[i].Number));
					command.Parameters.Add(new($"pin{i}", entities[i].Pin));
					command.Parameters.Add(new($"name{i}", entities[i].Name));
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
		private bool IsOld(Card entity)
		{
			if(entity.Deleted == null)
				return false;
			if((DateTime.Now - entity.Deleted).Value.TotalDays < 7)
				return false;
			return true;
		}
	}
}




