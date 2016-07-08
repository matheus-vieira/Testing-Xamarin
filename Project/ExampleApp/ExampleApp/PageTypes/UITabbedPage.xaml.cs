using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExampleApp.PageTypes
{
    public partial class UITabbedPage : TabbedPage
    {
        public UITabbedPage()
        {
            InitializeComponent();
        }

        protected async void OnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new UICarrosselPage());
        }
    }
}
