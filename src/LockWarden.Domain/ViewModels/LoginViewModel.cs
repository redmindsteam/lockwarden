using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Domain.ViewModels
{
    public class LoginViewModel
    {
        public string Service { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public LoginViewModel(string service, string username, string password, string name)
        {
            Service = service;
            Username = username;
            Password = password;
            Name = name;
        }
    }
}
