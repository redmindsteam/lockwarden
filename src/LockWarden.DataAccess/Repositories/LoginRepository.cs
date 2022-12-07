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
                string query = "insert into Login(Deleted,UserId,Service,Username,Password,Name) " +
                    "values (@Deleted,@UserId,@Id,@Service,@Username,@Password,@Name );";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
                {
                    Parameters =
                    {
                        new SqliteParameter("Deleted",entity.Deleted),
                        new SqliteParameter("UserId",entity.UserId),
                        new SqliteParameter("Service",entity.Service),
                        new SqliteParameter("Username",entity.Username),
                        new SqliteParameter("Password",entity.Password),
                        new SqliteParameter("Name",entity.Name)

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
                string query = $"delete from Login where id={id};";
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

        public async Task<List<Login>> GetAllAsync()
        {
            try
            {
                await _sqliteConnection.OpenAsync();
                string query = "select * from Login;";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
                var readly = await command.ExecuteReaderAsync();
                List<Login> logins = new List<Login>();
                while (await readly.ReadAsync())
                {
                    Login login = new Login(readly.GetDateTime(0),readly.GetInt32(1), readly.GetInt32(2), readly.GetString(3), readly.GetString(4), readly.GetString(5), readly.GetString(6));
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
                string query = $"select * from Logins where id={id};";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
                var readly = await command.ExecuteReaderAsync();
                if (await readly.ReadAsync())
                {
                    Login Login = new Login(readly.GetDateTime(0), readly.GetInt32(1), readly.GetInt32(2), readly.GetString(3), readly.GetString(4), readly.GetString(5), readly.GetString(6));
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
                string query = "update Logins set Deleted=@Deleted, UserId=@UserId, Id=@Id,Service=@Service, Username=@Username, Password=@Password,Name=@Name;";
                SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
                {
                    Parameters =
                    {
                        new SqliteParameter("Deleted",entity.Deleted),
                        new SqliteParameter("UserId",entity.UserId),
                        new SqliteParameter("Id",entity.Id),
                        new SqliteParameter("Service",entity.Service),
                        new SqliteParameter("Username",entity.Username),
                        new SqliteParameter("Password",entity.Password),
                        new SqliteParameter("Name",entity.Name)
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

