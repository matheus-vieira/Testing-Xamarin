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

        public bool IsNotBusy
        {
            get { return !_IsBusy; }
        }

        private bool _IsBusy = false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
                PropertyChanged(this, new PropertyChangedEventArgs("IsNotBusy"));
            }
        }


        private string _user;
        public string User
        {
            get
            { return _user; }
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
            { return _items; }
            set
            {
                _items = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Items"));
            }
        }

        public ICommand Clicked { get; set; }

        public ViewModel()
        {
            Clicked = new Command(async o =>
            {
                IsBusy = true;
                Items = await GitHubApi.GetAsync(User);
                IsBusy = false;
            });
        }
    }
}
