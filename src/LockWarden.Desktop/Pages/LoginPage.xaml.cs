using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Domain.ViewModels;
using LockWarden.Service.Interfaces;
using LockWarden.Service.Services;
using LockWarden.Service.Tools;
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

            LoginViewModel loginViewModel;
            if (btnCheckbox.IsChecked == false)
            {
                 loginViewModel = new LoginViewModel(Web_site_login_page_tb.Text, username_Login_page_tb.Text, password_Login_page_tb.Password, name_login_page_tb.Text);
            }
            else
            {
                 loginViewModel = new LoginViewModel(Web_site_login_page_tb.Text, username_Login_page_tb.Text, password_Login_page_tbhidden.Text, name_login_page_tb.Text);
            }
                if (Helper.Validate(Valid.UserPasswordOrName, loginViewModel.Username) &&
                Helper.Validate(Valid.UserPasswordOrName, loginViewModel.Password) &&
                Helper.Validate(Valid.UserPasswordOrName, loginViewModel.Service))
                {
                var loginService = new LoginService();
                var result = await loginService.CreateAsync(loginViewModel, DB_Constants.UserPassword);
                MessageBox.Show(result.Message);
            }
            else
            {
                MessageBox.Show("To'g'ri to'ldirilmagan");

            }
            Web_site_login_page_tb.Text = ""; username_Login_page_tb.Text = ""; password_Login_page_tb.Password = ""; name_login_page_tb.Text = "";

        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (btnCheckbox.IsChecked == true)
            {
                password_Login_page_tbhidden.Text = password_Login_page_tb.Password;
                hiddenDockPanel.Visibility = Visibility.Visible;
                DockPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                password_Login_page_tb.Password = password_Login_page_tbhidden.Text;
                DockPanel.Visibility = Visibility.Visible;
                hiddenDockPanel.Visibility = Visibility.Collapsed;
            }
        }
    }
}
