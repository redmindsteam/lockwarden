using LockWarden.DataAccess.Interfaces;
using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Windows;
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

        private void FullNamePage_click(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new Pages.FullNamePage();
        }

        private void LoginPage_click(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new Pages.LoginPage();
        }

        private void CardPage_click(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new Pages.CardPage();
        }

        private void NotePage_click(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new Pages.NotePage();
        }

        private void ImagePage_click(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new Pages.ImagePage();
        }



        private void TrashPage_click(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new Pages.TrashPage();
        }


        private void MenuItem_Click_All(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new Pages.All_Records_Pages.All();
        }

        private void MenuItem_CardPage_click(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new Pages.All_Records_Pages.Card();
        }

        private void MenuItem_NotePage_click(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new Pages.All_Records_Pages.Note();
        }

        private void MenuItem_LoginPage_click(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new Pages.All_Records_Pages.Allitems();
        }
    }
}
