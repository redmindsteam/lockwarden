using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Interfaces;
using LockWarden.DataAccess.Interfaces.IRepositories;
using LockWarden.Domain.Models;
using Microsoft.Data.Sqlite;

namespace LockWarden.DataAccess.Repositories

{
    public class UserRepository : IUserRepository
    {

        private readonly SqliteConnection _sqliteConnection = new(DB_Constants.DB_Path_File);
        public async Task<bool> CreateAsync(User entity)
        {
            try
            {
                await _sqliteConnection.OpenAsync();
                string query = "insert into users(name,login,password_hash,salt) " +
                    "values (@name,@login,@password_hash,@salt);";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
                {
                    Parameters =
                    {
                        new SqliteParameter("name",entity.Name),
                        new SqliteParameter("login",entity.Login),
                        new SqliteParameter("password_hash",entity.PasswordHash),
                        new SqliteParameter("salt",entity.Salt)
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
                string query = $"delete from users where id={id};";
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

        public async Task<User> FindByLoginAsync(string login)
        {
            try
            {
                await _sqliteConnection.OpenAsync();
                string query = $"select * from users where login='{login}';";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
                var readly = await command.ExecuteReaderAsync();
                if (await readly.ReadAsync())
                {
                    User user = new User(readly.GetString(1), readly.GetString(2), readly.GetString(3), readly.GetString(4));
                    user.Id = readly.GetInt32(0);
                    return user;
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

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                await _sqliteConnection.OpenAsync();
                string query = $"select * from users;";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
                var readly = await command.ExecuteReaderAsync();
                List<User> users = new List<User>();
                while(await readly.ReadAsync())
                { 
                    User user = new User(readly.GetString(1), readly.GetString(2), readly.GetString(3), readly.GetString(4));
                    users.Add(user);
                }
                return users;
               
            }
            catch
            {
                return new List<User>();
            }
            finally
            {
                await _sqliteConnection.CloseAsync();
            }
        }

        public async Task<User> GetAsync(int id)
        {
            try
            {
                await _sqliteConnection.OpenAsync();
                string query = $"select * from users where id='{id}';";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
                var readly = await command.ExecuteReaderAsync();
                if (await readly.ReadAsync())
                {
                    User user = new User(readly.GetString(1), readly.GetString(2), readly.GetString(3), readly.GetString(4));
                    return user;
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

        public async Task<bool> UpdateAsync(int id, User entity)
        {
            try
            {
                await _sqliteConnection.OpenAsync();
                string query = "update users set name=@name, login=@login, password_hash=@password_hash,salt=@salt;" ;
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
                {
                    Parameters =
                    {
                        new SqliteParameter("name",entity.Name),
                        new SqliteParameter("login",entity.Login),
                        new SqliteParameter("password_hash",entity.PasswordHash),
                        new SqliteParameter("salt",entity.Salt),
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
