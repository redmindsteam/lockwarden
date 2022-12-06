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

namespace LockWarden.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for AllRecordsPage.xaml
    /// </summary>
    public partial class AllRecordsPage : Page
    {
        public AllRecordsPage()
        {
            InitializeComponent();
        }

        private void MergeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<10; i++)
            {
                var logincontrol = new LoginControls();
                loginControlStackPanel.Children.Add(logincontrol);
            }
        }
    }
}
