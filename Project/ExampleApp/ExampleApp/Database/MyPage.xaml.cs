using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExampleApp.Database
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var dados = new DAO())
            {
                List.ItemsSource = dados.Get();
            }
        }

        protected async void NovoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditContact(null));
        }

        protected async void ListItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new EditContact((Contato)e.Item));
        }
    }
}
