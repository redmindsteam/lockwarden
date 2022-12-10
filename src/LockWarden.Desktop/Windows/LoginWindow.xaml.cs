using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Pages;
using LockWarden.Domain.ViewModels;
using LockWarden.Service.Services;

using Microsoft.EntityFrameworkCore.Storage;

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
using System.Windows.Shapes;

namespace LockWarden.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    /// 

    public partial class LoginWindow : Window
    {
        Repository repository = new Repository();

        public   LoginWindow()
        {
            InitializeComponent();
            repository.Initialize();
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtemail.Focus();
        }

        private void txtemail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtemail.Text) && txtemail.Text.Length > 0) textEmail.Visibility = Visibility.Collapsed;
            else textEmail.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPasswords.Focus();
        }

        private void txtPasswords_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPasswords.Password) && txtPasswords.Password.Length > 0) textPassword.Visibility = Visibility.Collapsed;
            else textPassword.Visibility = Visibility.Visible;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoginBorder.Visibility = Visibility.Collapsed;
            RegsBorder.Visibility = Visibility.Visible;
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UserService userService = new  UserService();
            var result = await userService.LoginAsync(txtemail.Text, txtPasswords.Password);
            if(!result.IsSuccesful)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                this.Close();
                MainWindow mainWindow = new MainWindow();
                DB_Constants.UserPassword= txtPasswords.Password;

                mainWindow.Show();
            }
        }
        private void textFullname_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtFullname.Focus();
        }


        private void txtFullname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFullname.Text) && txtFullname.Text.Length > 0) textFullname.Visibility = Visibility.Collapsed;
            else textFullname.Visibility = Visibility.Visible;
        }


        private void textEmailRegs_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            txtEmailRegs.Focus();
        }

        private void txtEmailRegs_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmailRegs.Text) && txtEmailRegs.Text.Length > 0) textEmailRegs.Visibility = Visibility.Collapsed;
            else textEmailRegs.Visibility = Visibility.Visible;
        }

        private void textPasswordRegs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtpaswordRegs.Focus();
        }

        private void txtpaswordRegs_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpaswordRegs.Password) && txtpaswordRegs.Password.Length > 0) textPasswordRegs.Visibility = Visibility.Collapsed;
            else textPasswordRegs.Visibility = Visibility.Visible;
        }

        private void textVerify_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtVerify.Focus();  
        }

        private void txtVerify_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVerify.Password) && txtVerify.Password.Length > 0) textVerify.Visibility = Visibility.Collapsed;
            else textVerify.Visibility = Visibility.Visible;
        }


        private async void Login_button(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService();
            if(btnCheckbox.IsChecked == false) 
            {
                var result = await userService.LoginAsync(txtemail.Text, txtPasswords.Password);
                if (!result.IsSuccesful)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    DB_Constants.UserPassword = txtPasswords.Password;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            else
            {
                var result = await userService.LoginAsync(txtemail.Text, txtPasswordbox.Text);
                if (!result.IsSuccesful)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    DB_Constants.UserPassword = txtPasswords.Password;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            
        }

        private void Register_button(object sender, RoutedEventArgs e)
        {
            RegsBorder.Visibility = Visibility.Visible;
            LoginBorder.Visibility = Visibility.Collapsed;
        }

        private void register_back(object sender, RoutedEventArgs e)
        {
            LoginBorder.Visibility = Visibility.Visible;
            RegsBorder.Visibility = Visibility.Collapsed;
        }

        private async void Register_verify_button(object sender, RoutedEventArgs e)
        {
            if(btnCheckboxregs.IsChecked == false)
            {
                try
                {
                    if (txtpaswordRegs.Password == txtVerify.Password&& txtpaswordRegs.Password.Length > 6)
                    {
                        UserViewModel userViewModel = new UserViewModel(txtFullname.Text, txtEmailRegs.Text, txtpaswordRegs.Password);
                        UserService userService = new UserService();
                        var result = await userService.RegistrationAsync(userViewModel);
                        if (result.IsSuccesful)
                        {
                            MessageBox.Show("Muvaffaqqiyatli ro'yxatdan o'tdingiz");
                            LoginWindow loginWindow = new LoginWindow();
                            this.Close();
                            loginWindow.Show();
                        }
                        else MessageBox.Show("Bunday foydalanuvchi mavjud");

                    }
                    else MessageBox.Show("Parolda xatolik mavjud");
                }
                catch
                {
                    MessageBox.Show("Xatolik!");
                }
                finally
                {
                    txtFullname.Text = "";
                    txtEmailRegs.Text = "";
                    txtpaswordRegs.Password = "";
                    txtVerify.Password = "";
                }
            }
            else
            {
                try
                {
                    if (txtpaswordRegshidden.Text == txtVerifyhidden.Text&& txtpaswordRegshidden.Text.Length>6)
                    {
                        UserViewModel userViewModel = new UserViewModel(txtFullname.Text, txtEmailRegs.Text, txtpaswordRegshidden.Text);
                        UserService userService = new UserService();
                        var result = await userService.RegistrationAsync(userViewModel);
                        if (result.IsSuccesful)
                        {
                            MessageBox.Show("Muvaffaqqiyatli ro'yxatdan o'tdingiz");
                            LoginWindow loginWindow = new LoginWindow();
                            this.Close();
                            loginWindow.Show();
                        }
                        else MessageBox.Show("Bunday foydalanuvchi mavjud");

                    }
                    else MessageBox.Show("Parolda xatolik mavjud");
                }
                catch
                {
                    MessageBox.Show("Xatolik!");
                }
                finally
                {
                    txtFullname.Text = "";
                    txtEmailRegs.Text = "";
                    txtpaswordRegshidden.Text = "";
                    txtVerifyhidden.Text = "";
                }
            }
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (btnCheckbox.IsChecked == true)
            {
                txtPasswordbox.Text = txtPasswords.Password;
                passwordBorder2.Visibility = Visibility.Visible;
                passwordBorder.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPasswords.Password = txtPasswordbox.Text;
                passwordBorder2.Visibility = Visibility.Collapsed;
                passwordBorder.Visibility = Visibility.Visible;
            }
        }

        private void txtPasswordbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textPasswordbox.Text) && textPasswordbox.Text.Length > 0) textPasswordbox.Visibility = Visibility.Collapsed;
            else textPasswordbox.Visibility = Visibility.Visible;
        }

        private void textPasswordbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPasswordbox.Focus();
        }

        private void textPasswordRegs_MouseDownhidden(object sender, MouseButtonEventArgs e)
        {
            txtpaswordRegshidden.Focus();
        }

        private void txtpaswordRegs_PasswordChangedhidden(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textPasswordRegshidden.Text) && textPasswordRegshidden.Text.Length > 0) textPasswordRegshidden.Visibility = Visibility.Collapsed;
            else txtpaswordRegshidden.Visibility = Visibility.Visible;
        }

        private void CheckBox_Changed_Regs(object sender, RoutedEventArgs e)
        {
            if (btnCheckboxregs.IsChecked == true)
            {
                txtpaswordRegshidden.Text = txtpaswordRegs.Password;
                RegsPasswordBorderHidden.Visibility = Visibility.Visible;
                RegsPasswordBorder.Visibility = Visibility.Collapsed;

                //verify

                txtVerifyhidden.Text = txtVerify.Password;
                RegsVerifyBorderhidden.Visibility = Visibility.Visible;
                RegsVerifyBorder.Visibility = Visibility.Collapsed;

            }
            else
            {
                txtpaswordRegs.Password = txtpaswordRegshidden.Text;
                RegsPasswordBorderHidden.Visibility = Visibility.Collapsed;
                RegsPasswordBorder.Visibility = Visibility.Visible;

                //verify
                txtVerify.Password = txtVerifyhidden.Text;
                RegsVerifyBorderhidden.Visibility = Visibility.Collapsed;
                RegsVerifyBorder.Visibility = Visibility.Visible;

            }
        }

        private void textVerify_MouseDownhidden(object sender, MouseButtonEventArgs e)
        {
            txtVerifyhidden.Focus();
        }

        private void txtVerify_PasswordChangedhidden(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVerifyhidden.Text) && txtVerifyhidden.Text.Length > 0) textVerifyhidden.Visibility = Visibility.Collapsed;
            else textVerifyhidden.Visibility = Visibility.Visible;
        }
    }
}
