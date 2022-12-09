using LockWarden.DataAccess.Constants;
using LockWarden.Desktop.Components;
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
    /// Interaction logic for Note.xaml
    /// </summary>
    public partial class Note : Page
    {
        private readonly INoteService noteService;
        public Note()
        {
            InitializeComponent();
            noteService = new NoteService();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var notes = await noteService.GetAllAsync(IdentitySingelton.GetInstance().UserId, DB_Constants.UserPassword);
            foreach(var note in notes.notes)
            {
                NoteControls noteControls = new NoteControls();
                noteControls.Notetitle.Text = note.Header;
                noteControls.Notedescription.Text ="";
                noteControls.Uid = note.Id.ToString();
                loginControlStackPanel.Children.Add(noteControls);
            }
        }
    }
}
