using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Domain.ViewModels
{
    public class CardViewModel
    {
        public string Bank { get; set; }
        public string Number { get; set; }
        public string Pin { get; set; }
        public string Name { get; set; }

        public CardViewModel(string bank, string number, string pin, string name)
        {
            Bank = bank;
            Number = number;
            Pin = pin;
            Name = name;
        }
    }
}
