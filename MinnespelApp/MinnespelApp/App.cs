using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MinnespelApp
{
    public class App : Application
    {
        public App()
        {
            // The root page of my application
          try {
                MainPage = new NavigationPage(new MainPage()); ;

            }catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
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
