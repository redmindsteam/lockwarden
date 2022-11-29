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
				textEmail.Visibility = Visibility.Collapsed;
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
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPasswords.Visibility = Visibility.Visible;
            }
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Login");
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
            GridLogin.Visibility = Visibility.Collapsed;
			GridRegs.Visibility = Visibility.Visible;
        }

		private void txtFullname_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
            if (!string.IsNullOrEmpty(txtFullname.Text) && txtFullname.Text.Length > 0)
            {
                textFullName.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtFullname.Visibility = Visibility.Visible;
            }
        }

		private void textFullName_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			txtFullname.Focus();
		}

		private void txtPhone_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
            if (!string.IsNullOrEmpty(txtPhone.Text) && txtPhone.Text.Length > 0)
            {
                textPhone.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPhone.Visibility = Visibility.Visible;
            }
        }

		private void textPhone_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			txtPhone.Focus();
		}

		private void txtEmailregs_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
            if (!string.IsNullOrEmpty(txtEmailregs.Text) && txtEmailregs.Text.Length > 0)
            {
                textEmailregs.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtEmail.Visibility = Visibility.Visible;
            }
        }

		private void textEmailregs_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			txtEmailregs.Focus();
		}

		private void textPasswordregs_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			txtpasswordregs.Focus();
		}

		private void txtpasswordregs_PasswordChanged(object sender, RoutedEventArgs e)
		{
            if (!string.IsNullOrEmpty(txtpasswordregs.Password) && txtpasswordregs.Password.Length > 0)
            {
                textPasswordregs.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtpasswordregs.Visibility = Visibility.Visible;
            }
        }

		private void textVerify_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			txtVerify.Focus();
		}

		private void txtVerify_PasswordChanged(object sender, RoutedEventArgs e)
		{
            if (!string.IsNullOrEmpty(txtVerify.Password) && txtVerify.Password.Length > 0)
            {
                textVerify.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtVerify.Visibility = Visibility.Visible;
            }
        }
	}
}
