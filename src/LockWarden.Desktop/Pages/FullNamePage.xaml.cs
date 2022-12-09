using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Interfaces.IRepositories;
using LockWarden.DataAccess.Repositories;
using LockWarden.Domain.Models;
using LockWarden.Domain.ViewModels;
using LockWarden.Service.Commons;
using LockWarden.Service.Interfaces;
using LockWarden.Service.Services;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LockWarden.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for FullNamePage.xaml
    /// </summary>
    public partial class FullNamePage : Page
    {
         public FullNamePage()
        {
            InitializeComponent();
            full_name_email_tb.Text = UserLogin().Result.Name;
            full_name_tb.Text = UserLogin().Result.Login;
            Password_pb.Text = DB_Constants.UserPassword;
            
        }
       public async Task<User> UserLogin()
        {
            var user_id = IdentitySingelton.GetInstance().UserId;
            IUserRepository userRepository = new UserRepository();
            var user = await userRepository.GetAsync(user_id);
            return user;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UserViewModel userViewModel = new UserViewModel(full_name_email_tb.Text, full_name_tb.Text, Password_pb.Text);
            IUserService userService = new UserService();
             var result = await userService.UpdateAsync(userViewModel);
            MessageBox.Show(result.Message);


        }
    }
}
