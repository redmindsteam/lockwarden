using LockWarden.DataAccess.Repositories;
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
    /// Interaction logic for CardControls.xaml
    /// </summary>
    public partial class CardControls : UserControl
    {
        public static bool checkcard;
        public static int CardId;
        public CardControls(int id)
        {
            InitializeComponent();
            CardId = id;
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!checkcard)
            {
                Repository repository = new Repository();
                CardWindow info = new CardWindow(CardId);
                info.Show();
                info.Activate();
                info.Topmost = true;
                checkcard = true;
            }
        }
    }
}
