using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Interfaces.IRepositories;
using LockWarden.DataAccess.Repositories;
using LockWarden.Domain.ViewModels;
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

namespace LockWarden.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for NotePage.xaml
    /// </summary>
    public partial class NotePage : Page
    {
        public NotePage()
        {
            InitializeComponent();
        }

        private async void Create_Note(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(text_note_page_tb.Document.ContentStart, text_note_page_tb.Document.ContentEnd);
            NoteViewModel noteViewModel = new NoteViewModel(title_note_page_tb.Text, textRange.Text);
            if (Helper.Validate(Valid.Text,noteViewModel.Content) &&
                Helper.Validate(Valid.Text,noteViewModel.Header))
            {
                INoteService noteService = new NoteService();
                var result = await noteService.CreateAsync(noteViewModel, DB_Constants.UserPassword);
                MessageBox.Show(result.Message);
            }
            else
            {
                MessageBox.Show("Noto'g'ri ma'lumot kritildi");
            }
        }
    }
}
