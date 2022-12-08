using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Components;
using LockWarden.Domain.Models;
using LockWarden.Service.Commons;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LockWarden.Desktop.Pages.All_Records_Pages
{
    /// <summary>
    /// Interaction logic for Allitems.xaml
    /// </summary>
    public partial class Allitems : Page
    {
        
        public Allitems()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Repository repository = new Repository();
            var logins = await repository.Logins.GetAllAsync();
            var userlogins = new List<Login>();
            foreach (var user in logins)
            {
                if (user.UserId == IdentitySingelton.GetInstance().UserId)
                    userlogins.Add(user);
            }
            foreach (var login in userlogins)
            {
                LoginControls loginControls = new LoginControls();
                loginControls.LoginControltitle.Text = login.Name;
                loginControls.LoginControlName.Text = login.Service;
                loginControls.Uid = login.Id.ToString();
                try
                {

                    loginControls.imageIcon.ImageSource = new BitmapImage(new Uri($"https://{login.Service}/favicon.ico"));
                    loginControlStackPanel.Children.Add(loginControls);
                }
                catch
                {
                    var str = new FileInfo("Assets/Icons/LoginControlDefaultWebIcon.png").FullName;
                    loginControls.imageIcon.ImageSource = new BitmapImage(new Uri("https://google.com/favicon.ico"));
                    loginControlStackPanel.Children.Add(loginControls);
                }
            }
            for (int i = 0; i < 20; i++)
            {
                var cardControl = new CardControls(CardControls.CardId);
                var imageControl = new ImageControl(ImageControl.ImageId);
                loginControlStackPanel.Children.Add(cardControl);
                loginControlStackPanel.Children.Add(imageControl);
            }

        }
    }
}
