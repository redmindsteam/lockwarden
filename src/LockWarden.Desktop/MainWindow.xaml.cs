using LockWarden.DataAccess.Interfaces;
using LockWarden.DataAccess.Repositories;
using System.Linq;
using System.Windows;

namespace LockWarden.Desktop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ITableCreate tableCreate = new TableCreate();
		public MainWindow()
		{
		
			InitializeComponent();
            CreateDatabase createDatabase = new CreateDatabase();
            createDatabase.DatabaseCreate();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
