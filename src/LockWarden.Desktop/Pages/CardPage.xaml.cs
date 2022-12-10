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
            


            CardViewModel cardViewModel;
           
            if(btnCheckbox.IsChecked == false)
            {
                cardViewModel = new CardViewModel(bank_card_page_tb.Text, number_card_page_tb.Text, pin_card_page_tb.Password, name_card_page_tb.Text);
            }
            else
            {
                cardViewModel = new CardViewModel(bank_card_page_tb.Text, number_card_page_tb.Text, pin_card_page_tbhidden.Text, name_card_page_tb.Text);
            }
            
            if (Helper.Validate(Valid.CardPin, cardViewModel.Pin) &&
                Helper.Validate(Valid.CardNumber, cardViewModel.Number)&&
                Helper.Validate(Valid.Text,cardViewModel.Bank)&&
                Helper.Validate(Valid.Text,cardViewModel.Name))
                {
                var cardService = new CardService();
                var result = await cardService.CreateAsync(cardViewModel, DB_Constants.UserPassword);
                MessageBox.Show(result.Message);
                MessageBox.Show(cardViewModel.Bank + "\n" + cardViewModel.Pin + "\n" + cardViewModel.Name + "\n" + cardViewModel.Number);
            }
            else
            {
                MessageBox.Show("Noto'g'ri ma'lumot kritildi");
            }
            bank_card_page_tb.Text = "";
            number_card_page_tb.Text = "";
            pin_card_page_tbhidden.Text = "";
            pin_card_page_tb.Password = "";
            name_card_page_tb.Text = "";
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (btnCheckbox.IsChecked == true)
            {
                pin_card_page_tbhidden.Text = pin_card_page_tb.Password;
                hiddenDockPanel.Visibility = Visibility.Visible;
                DockPanelPin.Visibility = Visibility.Collapsed;
            }
            else
            {
                pin_card_page_tb.Password = pin_card_page_tbhidden.Text;
                DockPanelPin.Visibility = Visibility.Visible;
                hiddenDockPanel.Visibility = Visibility.Collapsed;
            }
        }
    }
}
