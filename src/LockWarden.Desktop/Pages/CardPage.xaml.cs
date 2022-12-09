using LockWarden.DataAccess.Constants;
using LockWarden.Domain.ViewModels;
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

namespace LockWarden.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for CardPage.xaml
    /// </summary>
    public partial class CardPage : Page
    {
        public CardPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
                CardViewModel cardViewModel = new CardViewModel(bank_card_page_tb.Text, number_card_page_tb.Text, pin_card_page_tb.Password, name_card_page_tb.Text);
            if (Helper.Validate(Valid.CardPin,pin_card_page_tb.Password) &&
                Helper.Validate(Valid.CardNumber,number_card_page_tb.Text)&&
                Helper.Validate(Valid.Text,name_card_page_tb.Text)&&
                Helper.Validate(Valid.Text,bank_card_page_tb.Text))
                {
                var cardService = new CardService();
                var result = await cardService.CreateAsync(cardViewModel, DB_Constants.UserPassword);
                MessageBox.Show(result.Message); 
            }
            else
            {
                MessageBox.Show("Noto'g'ri ma'lumot kritildi");
            }
        }
    }
}
