using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Domain.Models;

public class Login : IUsable
{
    public int Id { get; set; }
    public DateTime? Deleted { get; set; }
    public string Service { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }

    public Login(DateTime deleted, string service, string username, string password, string name, int userId)
    {
        Deleted = deleted;
        Service = service;
        Username = username;
        Password = password;
        Name = name;
        UserId = userId;
    }
}
