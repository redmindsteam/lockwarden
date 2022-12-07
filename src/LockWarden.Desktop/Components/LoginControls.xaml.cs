using LockWarden.Desktop.Windows.InfoWindows;
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

        public static bool check;
        public LoginControls()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (!check)
            {
                LoginInfo info = new LoginInfo();
                info.Show();
                info.Activate();
                info.Topmost= true;
                check= true;
            }
        }

        
    }
}
