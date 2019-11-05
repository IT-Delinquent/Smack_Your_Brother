using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
    public class PopupViewModel : Screen
    {
        private string _header;

        public string Header
        {
            get { return _header; }
            set 
            { 
                _header = value;
                NotifyOfPropertyChange(() => Header);
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        public void UpdateMessage(string header, string message)
        {
            Header = header;
            Message = message;
        }

        public void Close()
        {
            TryClose();
        }
    }
}