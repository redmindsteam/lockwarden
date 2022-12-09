using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Windows.InfoWindows;
using LockWarden.Service.Interfaces;
using LockWarden.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LockWarden.Desktop.Components
{
    /// <summary>
    /// Interaction logic for LoginControls.xaml
    /// </summary>
    public partial class LoginControls : UserControl
    {
        private readonly ILoginService loginService;
        public static bool check;
        public LoginControls()
        {
            InitializeComponent();
            loginService= new LoginService();
        }

        private async void UserControl_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (!check)
            {
                var login = await loginService.GetAsync(int.Parse(Uid),DB_Constants.UserPassword);
                LoginInfo info = new LoginInfo();
                info.LoginName.Text = login.loginView.Name;
                info.LoginUsername.Text = login.loginView.Username;
                info.LoginPassword.Password = login.loginView.Password;
                info.LoginWebSite.Text = login.loginView.Service;
                info.Uid = login.loginView.Id.ToString();
                info.Show();
                info.Activate();
                info.Topmost= true;
                check= true;
            }
        }

        
    }
}
