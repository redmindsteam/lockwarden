using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Components;
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

namespace LockWarden.Desktop.Pages.All_Records_Pages
{
    /// <summary>
    /// Interaction logic for All.xaml
    /// </summary>
    public partial class All : Page
    {
        public All()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Repository repository = new Repository();
            var logins = await repository.Logins.GetAllAsync();
            foreach(var login in logins)
            {
                LoginControls loginControls = new LoginControls();
                loginControls.LoginControltitle.Text=login.Name;
                loginControls.LoginControlName.Text = login.Service;
                loginControls.Uid = login.Id.ToString();
            }
        }
    }
}
