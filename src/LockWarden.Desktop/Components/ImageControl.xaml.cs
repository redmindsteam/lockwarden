using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Windows.InfoWindows;
using LockWarden.Service.Interfaces;
using LockWarden.Service.Services;
using LockWarden.Service.Tools;
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
    /// Interaction logic for ImageControl.xaml
    /// </summary>
    public partial class ImageControl : UserControl
    {
        private readonly IImageService imageService;
        public static bool checkImage;
        public ImageControl()
        {
            InitializeComponent();
            imageService = new ImageService();
        }
        
        private async void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!checkImage)
            {
                var image = await imageService.GetAsync(int.Parse(Uid),DB_Constants.UserPassword);
                ImageWindow info = new ImageWindow();
                info.bank_card_page_tb.Text = image.image.Name;
                info.Show();
                info.Activate();
                info.Topmost = true;
                checkImage = true;
                
            }
        }
    }
}
