using LockWarden.Desktop.Components;
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

namespace LockWarden.Desktop.Windows.InfoWindows
{
    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        public static int ImageId;
        public ImageWindow(int id)
        {
            InitializeComponent();
            ImageId=id;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonBack_click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ImageControl.checkImage = false;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
