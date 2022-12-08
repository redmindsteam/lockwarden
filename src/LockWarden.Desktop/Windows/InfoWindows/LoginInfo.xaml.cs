using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Components;
using LockWarden.Desktop.Pages.All_Records_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LockWarden.Desktop.Windows.InfoWindows
{
    /// <summary>
    /// Interaction logic for LoginInfo.xaml
    /// </summary>
    public partial class LoginInfo : Window
    {
        public static int LoginId;
        public LoginInfo(int id)
        {
            LoginId = id;
            InitializeComponent();
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
            Repository repository = new Repository();
            All all = new All();
            await repository.Logins.DeleteAsync(LoginId);
        }

        private void Edit(object sender, RoutedEventArgs e)
        {

        }
    }
}
