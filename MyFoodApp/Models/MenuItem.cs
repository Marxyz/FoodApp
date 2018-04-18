using System;
using System.Windows.Input;

namespace MyFoodApp.Models
{
    public class MenuItem : BaseViewModel
    {
        private DelegateCommand _command;
        private Type _navigationDestination;


        public string Glyph { get; set; }

        public string Text { get; set; }

        public ICommand Command
        {
            get { return _command; }
            set { SetProperty(ref _command, value as DelegateCommand); }
        }

        public Type NavigationDestination
        {
            get { return _navigationDestination; }
            set { SetProperty(ref _navigationDestination, value); }
        }

        public bool HasNavigationDestination => _navigationDestination != null;
    }
}