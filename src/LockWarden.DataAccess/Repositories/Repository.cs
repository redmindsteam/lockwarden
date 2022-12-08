using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Interfaces.IRepositories;
using LockWarden.Domain.Models;

using Microsoft.Data.Sqlite;

namespace LockWarden.DataAccess.Repositories;

public class Repository
{
	public IUserRepository Users { get; set; }
	public INoteRepository Notes { get; set; }
	public IImageRepository Images { get; set; }
	public ILoginRepository Logins { get; set; }
	public ICardRepository Cards { get; set; }

	public Repository()
	{
		Users = new UserRepository();
		Notes = new NoteRepository();
		Images = new ImageRepository();
		Logins = new LoginRepository();
		Cards = new CardRepository();
	}
	private bool DataBaseExists()
	{
		string file = DB_Constants.DB_Path_File.Split("=")[1];
		return new FileInfo(file).Exists;
	}
	public async void Initialize()
	{
		if(!DataBaseExists())
		{
			await CreateDataBaseAsync();
		}
	}
	private async Task<bool> CreateDataBaseAsync()
	{
		SqliteConnection _sqliteConnection = new(DB_Constants.DB_Path_File);
		try
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			string dirpath = path + "\\Lock Warden";
			string filepath = dirpath + "\\lock-warden.db";
			Directory.CreateDirectory(dirpath);
			File.WriteAllText(filepath, "");
			await _sqliteConnection.OpenAsync();
			string query = "CREATE TABLE users (id INTEGER PRIMARY KEY, name TEXT NOT NULL, login TEXT NOT NULL UNIQUE, password_hash TEXT NOT NULL  ,  salt TEXT NOT NULL );\n" +
				   " CREATE TABLE logins (id INTEGER PRIMARY KEY, deleted TEXT , service TEXT NOT NULL, username TEXT NOT NULL ,  password TEXT NOT NULL,name TEXT NOT NULL,user_id INTEGER NOT NULL,FOREIGN KEY(user_id )  REFERENCES users (id)) ;\n " +
				   " CREATE TABLE cards (id INTEGER PRIMARY KEY, deleted TEXT , bank TEXT NOT NULL, number TEXT NOT NULL ,  pin TEXT NOT NULL,name TEXT NOT NULL,user_id INTEGER NOT NULL,FOREIGN KEY(user_id )  REFERENCES users (id)) ; \n" +
				   " CREATE TABLE notes (id INTEGER PRIMARY KEY, deleted TEXT , header TEXT NOT NULL, content TEXT NOT NULL, user_id INTEGER NOT NULL,FOREIGN KEY(user_id )  REFERENCES users (id)) ;\n " +
				   " CREATE TABLE images (id INTEGER PRIMARY KEY, deleted TEXT , name TEXT NOT NULL, content TEXT NOT NULL, user_id INTEGER NOT NULL,FOREIGN KEY(user_id )  REFERENCES users (id)) ; \n";
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
}
