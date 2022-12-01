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
	}
}
