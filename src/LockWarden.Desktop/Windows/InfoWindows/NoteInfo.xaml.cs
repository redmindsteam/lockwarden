using LockWarden.DataAccess.Constants;
using LockWarden.Desktop.Components;
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
    /// Interaction logic for NoteInfo.xaml
    /// </summary>
    public partial class NoteInfo : Window
    {
        private readonly INoteService noteService;
        public NoteInfo()
        {
            InitializeComponent();
            noteService = new NoteService();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonBack_click(object sender, RoutedEventArgs e)
        {
            this.Close();
            NoteControls.checknote = false;
        }

        private async void Edit(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(text_note_page_tb.Document.ContentStart, text_note_page_tb.Document.ContentEnd);
            NoteViewModel noteViewModel = new NoteViewModel(title_note_page_tb.Text,textRange.Text);
            var result = await noteService.UpdateAsync(noteViewModel, DB_Constants.UserPassword, Convert.ToInt32(Uid));
            MessageBox.Show(result.Message);
            LoginControls.check = false;
        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            await noteService.DeleteAsync(Convert.ToInt32(Uid), DB_Constants.UserPassword);
            this.Close();
            MessageBox.Show("Deleted");
            CardControls.checkcard = false;
        }
    }
}
