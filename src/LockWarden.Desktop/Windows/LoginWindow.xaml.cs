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
        public LoginWindow()
        {
            InitializeComponent();
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

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

        //private void Button_Click_4(object sender, RoutedEventArgs e)
        //{

        //}

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            RegsBorder.Visibility = Visibility.Collapsed;
            LoginBorder.Visibility = Visibility.Visible;  
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
