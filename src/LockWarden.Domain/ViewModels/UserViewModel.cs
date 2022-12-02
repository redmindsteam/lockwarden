using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Domain.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; } = String.Empty;
        public string Login { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public UserViewModel(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }
    }
}
