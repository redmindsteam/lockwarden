using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Interfaces;
using LockWarden.Domain.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.DataAccess.Repositories
{
    public class TableCreate : ITableCreate
    {
        private readonly SqliteConnection _sqliteConnection = new(DB_Constants.DB_Path);
        public async Task<bool> CreateTableAsync()
        { 
               try
                {
                    await _sqliteConnection.OpenAsync();
                    string query = "CREATE TABLE users (id INTEGER PRIMARY KEY, name TEXT NOT NULL, login TEXT NOT NULL UNIQUE, password_hash TEXT NOT NULL  ,  salt TEXT NOT NULL );"+
                                   " CREATE TABLE logins (id INTEGER PRIMARY KEY, deleted TEXT , service TEXT NOT NULL, username TEXT NOT NULL ,  password TEXT NOT NULL,name TEXT NOT NULL,user_id INTEGER NOT NULL,FOREIGN KEY(user_id )  REFERENCES users (id)) ;\n " +
                                   " CREATE TABLE cards (id INTEGER PRIMARY KEY, deleted TEXT , bank TEXT NOT NULL, number TEXT NOT NULL ,  pin TEXT NOT NULL,name TEXT NOT NULL,user_id INTEGER NOT NULL,FOREIGN KEY(user_id )  REFERENCES users (id)) ; \n" +
                                   " CREATE TABLE notes (id INTEGER PRIMARY KEY, deleted TEXT , header TEXT NOT NULL, content TEXT NOT NULL, user_id INTEGER NOT NULL,FOREIGN KEY(user_id )  REFERENCES users (id)) ;\n "+
                                   " CREATE TABLE image (id INTEGER PRIMARY KEY, deleted TEXT , name TEXT NOT NULL, content TEXT NOT NULL, user_id INTEGER NOT NULL,FOREIGN KEY(user_id )  REFERENCES users (id)) ; \n";
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
    }
}
