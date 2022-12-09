using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Windows;
using LockWarden.Domain.ViewModels;
using LockWarden.Service.Interfaces;
using LockWarden.Service.Services;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for ImagePage.xaml
    /// </summary>
    public partial class ImagePage : Page
    {
        public ImagePage()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog= new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.png";
            openFileDialog.FilterIndex= 1;
            if (openFileDialog.ShowDialog() == true)
            {
                imagePicture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                DB_Constants.ImagePath = openFileDialog.FileName;

            }
        }

        private async void Button_Click_save(object sender, RoutedEventArgs e)
        {

            ImageViewModel imageViewModel = new ImageViewModel(bank_card_page_tb.Text,DB_Constants.ImagePath);
            IImageService imageService = new ImageService();
            var result =await imageService.CreateAsync(imageViewModel,DB_Constants.UserPassword);
            MessageBox.Show(result.Message);
        }
    }
}
