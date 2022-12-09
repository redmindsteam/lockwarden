using LockWarden.DataAccess.Constants;
using LockWarden.Desktop.Components;
using LockWarden.Service.Commons;
using LockWarden.Service.Interfaces;
using LockWarden.Service.Services;
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

namespace LockWarden.Desktop.Pages.All_Records_Pages
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : Page
    {
        private readonly IImageService imageService;
        public Image()
        {
            InitializeComponent();
            imageService = new ImageService();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var images = await imageService.GetAllAsync(IdentitySingelton.GetInstance().UserId, DB_Constants.UserPassword);
            foreach(var image in images.images)
            {
                ImageControl control = new ImageControl();
                control.ImageTitle.Text=image.Name;
                control.ImageDescriptioon.Text = "";
                control.Imagephoto.ImageSource = new BitmapImage(new Uri(image.Content));
            }
        }
    }
}
