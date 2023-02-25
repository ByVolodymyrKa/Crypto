using Crypto.Commands;
using Crypto.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Crypto.ViewModel
{
    public class AppVewModel : BaseViewModel
    {
        public string Text
        {
            get => _text;
            set
            {
                if (Text != value)
                {
                    _text = value;
                    OnPropertyChanged(typeof(Text).Name);
                }
            }
        }
        private string _text { get; set; }

        public Command ChangeName { get => changeName;}
        private Command changeName;

        public AppVewModel()
        {
            _text = "button";
            changeName = new Command(obj => ResetButton());
        }

        public void ResetButton()
        {
            Text = "Hui";

            
        }
    }
}
