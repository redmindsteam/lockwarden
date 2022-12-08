using LockWarden.DataAccess.Repositories;
using LockWarden.Domain.ViewModels;
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

namespace LockWarden.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginViewModel loginViewModel = new LoginViewModel(Web_site_login_page_tb.Text,username_Login_page_tb.Text,password_Login_page_tb.Password,name_login_page_tb.Text);
            var loginService = new LoginService();
            var result = await loginService.CreateAsync(loginViewModel, "123");
            MessageBox.Show(result.Message);
        }
    }
}
