using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Windows.InfoWindows;
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

namespace LockWarden.Desktop.Components
{
    /// <summary>
    /// Interaction logic for CardControls.xaml
    /// </summary>
    public partial class CardControls : UserControl
    {
        public static bool checkcard;
        public static int CardControlId;
        public CardControls()
        {
            InitializeComponent();
            
        }

        private async void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!checkcard)
            {
                ICardService cardService = new CardService();
                var card = await cardService.GetAsync(int.Parse(Uid),DB_Constants.UserPassword);
                CardWindow info = new CardWindow(int.Parse(Uid));
                info.Bankname.Text = card.card.Bank;
                info.cardname.Text=card.card.Name;
                info.pin.Password = card.card.Pin;
                info.cardNumber.Text = card.card.Number;
                info.Uid = card.card.Id.ToString() ;
                info.Show();
                info.Activate();
                info.Topmost = true;
                checkcard = true;
            }
        }
    }
}
