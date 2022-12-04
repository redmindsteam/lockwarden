using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;

class Program
{
    private readonly SqliteConnection _sqliteConnection = new(DBConstants.DB_Path);
    public static void Main()
    {
        
         public Task<bool> CreateAsync(T entity);
        public interface IUserRepository : IGenericRepository<User>;
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