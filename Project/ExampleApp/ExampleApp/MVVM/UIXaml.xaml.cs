using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExampleApp
{
    public partial class UIXaml : ContentPage
    {
        public UIXaml()
        {
            InitializeComponent();

            this.BindingContext = new ViewModel();
        }
    }
}
