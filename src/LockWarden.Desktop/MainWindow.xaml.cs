using System.Linq;
using System.Windows;

namespace LockWarden.Desktop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void textEmail_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			txtEmail.Focus();
		}

		private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			if(!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
			{
				txtEmail.Visibility = Visibility.Collapsed;
			}
			else
			{
				txtEmail.Visibility = Visibility.Visible;
			}
		}

		private void textPassword_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			txtPasswords.Focus();
		}

		private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
		{
            if (!string.IsNullOrEmpty(txtPasswords.Password) && txtPasswords.Password.Length > 0)
            {
                txtPasswords.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPasswords.Visibility = Visibility.Visible;
            }
        }
	}
}
