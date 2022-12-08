using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Domain.ViewModels
{
    public class ImageViewModel
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public ImageViewModel(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}
