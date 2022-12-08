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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LockWarden.Desktop.Pages.All_Records_Pages
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : Page
    {
        public Card()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                var cardControl = new CardControls(CardControls.CardId);
                loginControlStackPanel.Children.Add(cardControl);
            }
        }
    }
}
