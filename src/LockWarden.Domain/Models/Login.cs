using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Domain.Models;

public class Login : IUsable
{
	public DateTime Deleted { get; set; }
	public int UserId { get; set; }
	public int Id { get; set; }
	public string Service { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public string Name { get; set; }

	public Login(DateTime deleted, int userId, int id, string service, string username, string password, string name)
	{
		Deleted = deleted;
		UserId = userId;
		Id = id;
		Service = service;
		Username = username;
		Password = password;
		Name = name;
	}
}
