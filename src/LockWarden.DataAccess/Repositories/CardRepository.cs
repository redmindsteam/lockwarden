﻿using LockWarden.DataAccess.Constants;
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
				string query = "insert into cards(Deleted,UserId,Id,Bank,Number,Pin,Name) " +
					"values (@Deleted,@UserId,@Id,@Bank,@Number,@Pin,@Name);";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
				{
					Parameters =
					{
						new SqliteParameter("Deleted",entity.Deleted),
						new SqliteParameter("UserId",entity.UserId),
						new SqliteParameter("Id",entity.Id),
						new SqliteParameter("Bank",entity.Bank),
						new SqliteParameter("Number",entity.Number),
						new SqliteParameter("Pin",entity.Pin),
						new SqliteParameter("Name",entity.Name)
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
					Card card = new Card(readly.GetDateTime(0), readly.GetInt32(1), readly.GetInt32(2), readly.GetString(3), readly.GetString(4), readly.GetString(5), readly.GetString(6));
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
				string query = $"select * from cards where id='{id}';";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var readly = await command.ExecuteReaderAsync();
				if(await readly.ReadAsync())
				{
					Card card = new Card(readly.GetDateTime(0), readly.GetInt32(1), readly.GetInt32(2), readly.GetString(3), readly.GetString(4), readly.GetString(5), readly.GetString(6));
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
				string query = "update cards set Deleted=@Deleted, UserId=@UserId, Id=@Id,Bank=@Bank, Number=@Number, Pin=@Pin, Name=@Name;";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
				{
					Parameters =
					{
						new SqliteParameter("Deleted",entity.Deleted),
						new SqliteParameter("UserId",entity.UserId),
						new SqliteParameter("Id",entity.Id),
						new SqliteParameter("Bank",entity.Bank),
						new SqliteParameter("Number",entity.Number),
						new SqliteParameter("Pin",entity.Pin),
						new SqliteParameter("Name",entity.Name)
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
	}
}



