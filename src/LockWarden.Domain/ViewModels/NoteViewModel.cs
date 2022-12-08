using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Domain.ViewModels
{
    public class NoteViewModel
    {
        public string Header { get; set; }
        public string Content { get; set; }

        public NoteViewModel(string header, string content)
        {
            Header = header;
            Content = content;           
        }
    }
}
