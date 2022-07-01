using System;
using Xamarin.Forms;

namespace MinnespelApp
{
    public class MainPage : ContentPage
    {

        //Memory game: The randomly dealt card that can be increased or decreased 
        // according to the settings.The game ends when all cards are open.
        // It counts the number of attempts made by the person until all cards have been opened.
        // You can only click twice.The first click must be similar to the second card, otherwise the two
        // cards will be closed. And the person tries again, and so on.

        readonly Button btn;

        [Obsolete]
        public MainPage()
        {
            Title = "Main page";

            Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

            btn = new Button
            {          
                Text = "New Game",
                WidthRequest=150,
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand

            };
            var AboutBtn = new Button
            {
                
                Text ="  About ",
                WidthRequest=150,
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            AboutBtn.Clicked += AboutBtn_Clicked;
            btn.Clicked += Btn_Clicked;
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                   {
                        new StackLayout
                        {      Spacing=30,
                               Orientation=StackOrientation.Vertical,
                               Children = {
                               btn,AboutBtn
                        }
                    }
                }
            };
        }

        private async void AboutBtn_Clicked(object sender, EventArgs e)
        {
            // to my personal page
            await Navigation.PushAsync(new AboutPage());
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            // cards view
            await Navigation.PushAsync(new CardViewPage());
        }
    }
}
