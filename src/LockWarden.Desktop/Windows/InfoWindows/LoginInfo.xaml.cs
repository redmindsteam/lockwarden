using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Components;
using LockWarden.Desktop.Pages.All_Records_Pages;
using LockWarden.Domain.Models;
using LockWarden.Domain.ViewModels;
using LockWarden.Service.Commons;
using LockWarden.Service.Interfaces;
using LockWarden.Service.Services;
using System;
using System.Windows;
using System.Windows.Input;

namespace LockWarden.Desktop.Windows.InfoWindows
{
    /// <summary>
    /// Interaction logic for LoginInfo.xaml
    /// </summary>
    public partial class LoginInfo : Window
    {
      
        private readonly ILoginService loginService;
        public static int LoginId;
        public LoginInfo()
        {
            InitializeComponent();
            loginService = new LoginService() ;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ButtonBack_click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginControls.check = false;
        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            LoginId = Convert.ToInt32(Uid);
            await loginService.DeleteAsync(Convert.ToInt32(Uid),DB_Constants.UserPassword);
            this.Close();
            MessageBox.Show("Deleted");
            LoginControls.check = false;
        }

        private async void Edit(object sender, RoutedEventArgs e)
        {
            LoginViewModel model=new LoginViewModel(LoginWebSite.Text, LoginUsername.Text, LoginPassword.Text, LoginName.Text);
            var result = await loginService.UpdateAsync(model,DB_Constants.UserPassword, Convert.ToInt32(Uid));
            MessageBox.Show(result.Message);
            LoginControls.check = false;
        }
    }
}
