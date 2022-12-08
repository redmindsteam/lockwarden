using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Components;
using LockWarden.Domain.Models;
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
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : Page
    {
        private readonly ICardService cardService;
        public Card()
        {
            InitializeComponent();
            cardService = new CardService();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var cards = await cardService.GetAllAsync(IdentitySingelton.GetInstance().UserId, DB_Constants.UserPassword);

            foreach (var card in cards.cards)
            {
                CardControls cardControls = new CardControls();
                cardControls.cardname.Text = card.Name;
                cardControls.bankname.Text = card.Bank;
                cardControls.Uid = card.Id.ToString();
                loginControlStackPanel.Children.Add(cardControls);
            }
        }
    }
}
