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
    /// Interaction logic for NoteControls.xaml
    /// </summary>
    public partial class NoteControls : UserControl
    {
        public NoteControls()
        {
            InitializeComponent();
        }

        public static bool checknote;
        private void NoteControls_click(object sender, MouseButtonEventArgs e)
        {
            if (!checknote)
            {
                //Repository repository = new Repository();
                //var login = await repository.Logins.GetAsync(int.Parse(Uid));
                NoteInfo info = new NoteInfo();
                info.Show();
                info.Activate();
                info.Topmost = true;
                checknote = true;
            }
        }
    }
}
