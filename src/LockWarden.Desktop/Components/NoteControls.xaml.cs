using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Desktop.Windows.InfoWindows;
using LockWarden.Service.Interfaces;
using LockWarden.Service.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    /// Interaction logic for NoteControls.xaml
    /// </summary>
    public partial class NoteControls : UserControl
    {
        public static bool checknote;
        private readonly INoteService noteService;
        public NoteControls()
        {
            InitializeComponent();
            noteService = new NoteService();
        }

        private async void NoteControls_click(object sender, MouseButtonEventArgs e)
        {
            if (!checknote)
            {
                var note =await noteService.GetAsync(int.Parse(Uid),DB_Constants.UserPassword);
                NoteInfo info = new NoteInfo();
                info.title_note_page_tb.Text = note.note.Header;
                info.text_note_page_tb.AppendText(note.note.Content);
                info.Show();
                info.Activate();
                info.Uid = note.note.Id.ToString();
                info.Topmost = true;
                checknote = true;
            }
        }
    }
}
