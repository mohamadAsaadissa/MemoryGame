
using Xamarin.Forms;

namespace MinnespelApp
{
    public class AboutPage : ContentPage
    {
        // My personal PAGE 
        public AboutPage()
        {
            Padding = new Thickness(0, 10, 0, 10);
            Title = "My details";

            var vContentStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Black,

                Children = {
                       new Label { Text = "Name : Issa Mohamad", TextColor=Color.White },
                       new Label { Text = "Place : Sweden", TextColor=Color.White },

                }
            };

            Content = vContentStack;
        }
    }
}
