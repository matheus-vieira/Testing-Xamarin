using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExampleApp.PageTypes
{
    public partial class UIContentPage : ContentPage
    {
        public UIContentPage()
        {
            InitializeComponent();
        }

        protected async void OnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new UITabbedPage());
        }
    }
}
