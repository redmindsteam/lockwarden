using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Components;
using LockWarden.Desktop.Pages.All_Records_Pages;
using LockWarden.Domain.Models;
using LockWarden.Domain.ViewModels;
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
using System.Windows.Shapes;

namespace LockWarden.Desktop.Windows.InfoWindows
{
    /// <summary>
    /// Interaction logic for CardWindow.xaml
    /// </summary>
    public partial class CardWindow : Window
    {
        public static int CardId;
        private readonly ICardService  cardService;
        public CardWindow(int id)
        {
            InitializeComponent();
            cardService= new CardService();

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonBack_click(object sender, RoutedEventArgs e)
        {
            this.Close();
            CardControls.checkcard = false;
        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            CardId = Convert.ToInt32(Uid);
            await cardService.DeleteAsync(Convert.ToInt32(Uid), DB_Constants.UserPassword);
            this.Close();
            MessageBox.Show("Deleted");
            CardControls.checkcard = false;
        }

        private async void Update(object sender, RoutedEventArgs e)
        {
            CardViewModel cardViewModel = new CardViewModel(Bankname.Text,cardNumber.Text,pin.Password,cardname.Text);
            var result = await cardService.UpdateAsync(cardViewModel, DB_Constants.UserPassword, CardId);
            MessageBox.Show(result.ToString());
            LoginControls.check = false;
        }
    }
}