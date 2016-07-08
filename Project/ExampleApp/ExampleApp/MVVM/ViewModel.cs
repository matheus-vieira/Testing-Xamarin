using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleApp
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _user;
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                PropertyChanged(this, new PropertyChangedEventArgs("User"));
            }
        }

        private List<string> _items;
        public List<string> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Items"));
            }
        }

        public ICommand Clicked { get; set; }

        public ViewModel()
        {
            Clicked = new Command(async o => Items = await GitHubApi.GetAsync(User));
        }
    }
}
