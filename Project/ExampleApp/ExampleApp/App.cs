using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ExampleApp
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            //MainPage = new UIXaml();
            //MainPage = new PageTypes.UIContentPage();
            //MainPage = new PageTypes.UITabbedPage();
            //MainPage = new PageTypes.UICarrosselPage();
            MainPage = new NavigationPage(new PageTypes.UIContentPage());
            //MainPage = new Database.MyPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
