using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Interfaces.IRepositories;
using LockWarden.Domain.Models;

using Microsoft.Data.Sqlite;

namespace LockWarden.DataAccess.Repositories

{
	public class LoginRepository : ILoginRepository
	{

		private readonly SqliteConnection _sqliteConnection = new(DB_Constants.DB_Path_File);
		public async Task<bool> CreateAsync(Login entity)
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = "insert into logins(deleted,service,username,password,name,user_id) " +
					"values (@deleted,@service,@username,@password,@name,@user_id );";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
				{
					Parameters =
					{
						new SqliteParameter("deleted",entity.Deleted),
						new SqliteParameter("service",entity.Service),
						new SqliteParameter("username",entity.Username),
						new SqliteParameter("Password",entity.Password),
						new SqliteParameter("Name",entity.Name),
						new SqliteParameter("userId",entity.UserId),
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
				string query = $"delete from logins where id={id};";
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

		public async Task<List<Login>> GetAllAsync()
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = "select * from logins;";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var readly = await command.ExecuteReaderAsync();
				List<Login> logins = new List<Login>();
				while(await readly.ReadAsync())
				{
					Login login = new Login(readly.GetInt32(0), readly.GetDateTime(1), readly.GetString(2), readly.GetString(3), readly.GetString(4), readly.GetString(5), readly.GetInt32(6));
					logins.Add(login);
				}
				return logins;

			}
			catch
			{
				return new List<Login>();
			}
			finally
			{
				await _sqliteConnection.CloseAsync();
			}
		}

		public async Task<Login> GetAsync(int id)
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = $"select * from logins where id={id};";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var readly = await command.ExecuteReaderAsync();
				if(await readly.ReadAsync())
				{
					Login Login = new Login(readly.GetInt32(0), readly.GetDateTime(1), readly.GetString(2), readly.GetString(3), readly.GetString(4), readly.GetString(5), readly.GetInt32(2));
					return Login;
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

		public async Task<bool> UpdateAsync(int id, Login entity)
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = $"update logins set deleted=@deleted,service=@service, username=@username, password=@password,name=@name where id={id};";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
				{
					Parameters =
					{
						new SqliteParameter("deleted",entity.Deleted),
						new SqliteParameter("service",entity.Service),
						new SqliteParameter("username",entity.Username),
						new SqliteParameter("password",entity.Password),
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
				string query = $"delete from logins where user_id={userId};";
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
		public async Task<bool> AddAllAsync(List<Login> entities)
		{
			try
			{

				await _sqliteConnection.OpenAsync();
				string query = "insert into logins(deleted,service,username,password,name,user_id) values";
				for(int i = 0; i < entities.Count; i++)
				{
					query += $" (@deleted{i},@service{i},@username{i},@password{i},@name{i},@user_id{i}),";
				}
				query = query.TrimEnd(',');
				query += ";";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				for(int i = 0; i < entities.Count; i++)
				{
					command.Parameters.Add(new($"deleted{i}", entities[i].Deleted));
					command.Parameters.Add(new($"user_id{i}", entities[i].UserId));
					command.Parameters.Add(new($"service{i}", entities[i].Service));
					command.Parameters.Add(new($"username{i}", entities[i].Username));
					command.Parameters.Add(new($"password{i}", entities[i].Password));
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

