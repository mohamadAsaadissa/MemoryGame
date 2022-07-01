
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MinnespelApp
{
    public class CardViewPage : ContentPage
    {
        //Number of cards 12
        // player name Mohamad
        // Player Id 00001

        private readonly List<Card> mycards = new  Game(12,"Mohamad","00001").GetCards();

        // Cards names .
        // they are saved in Dir Resources / drawable
        private readonly string[] cardsNames={"C0.png", "C1.png", "C2.png", "C3.png", "C4.png",
            "C5.png", "C6.png", "C7.png", "C8.png", "C9.png", "C10.png"};

        private int NewValue1=0, NewValue2=0,incrmt=0;
        private static object Result=0;

       
        private static Image Removeimg;
     
        private readonly Label ScoreLbl;
        private Grid grid;
        private Image image;
        private readonly StackLayout ScoreLayout;
        private readonly Button backButton;

        public CardViewPage()
        {
            
            Title = "Game page";
            Padding = new Thickness(5, Device.OnPlatform(20, 5, 0), 5, 0);

            Label lbl = new Label
            {
                Text="Payer score:",
                HorizontalOptions =LayoutOptions.Start
            };
              ScoreLbl = new Label
            {
                Text = "0",
                 HorizontalOptions = LayoutOptions.Start
                ,
                  BackgroundColor=Color.Red
                , TextColor=Color.White
            };
            ScoreLayout = new StackLayout
            {
                Orientation= StackOrientation.Horizontal,
                Children = {lbl,ScoreLbl},
                Padding=new Thickness(2,2,0,5)
            };
           backButton = new Button
            {
                Text = "Back to the main page",              
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor=Color.Red
            };
            //go back to main page
            backButton.Clicked += async (s, a) =>
            {
                await Navigation.PopAsync();

            };

            incrmt = 0;
            GetImages.Init();
          
            DrawImages();//initial image

                  
            Content = new StackLayout
            {
                VerticalOptions=LayoutOptions.CenterAndExpand,
                HorizontalOptions=LayoutOptions.CenterAndExpand,

                Children = {
                  ScoreLayout, grid,backButton
                }
            };
           
        }

        private async void TapImage_Tapped(object sender, EventArgs e)
        {

            var row = (int)((BindableObject)sender).GetValue(Grid.RowProperty);
            var col = (int)((BindableObject)sender).GetValue(Grid.ColumnProperty);

            var NewValue = ((BindableObject)sender).GetValue(BindingContextProperty);//Get value of card
            //var IsEnable = (bool)((BindableObject)sender).GetValue(IsEnabledProperty);//Get enable value
            //var IsSelected = (bool)((BindableObject)sender).GetValue(IsVisibleProperty);//Get  visible value
            /*var classId = (string)((BindableObject)sender).GetValue(ClassIdProperty);*///Get  visible value

            var bb = cardsNames[int.Parse(NewValue.ToString())];
            ((BindableObject)sender).SetValue(Image.SourceProperty, bb);//set the new source for card
            ((BindableObject)sender).SetValue(IsEnabledProperty, true);//set the new  enable property for  card
            ((BindableObject)sender).SetValue(IsEnabledProperty, false);//set the new  enable property for  card
            incrmt++;
            if (incrmt >= 3) incrmt = 0;

            if (incrmt == 1)
            {
                NewValue1 = int.Parse(NewValue.ToString());

                Removeimg = GetImages.GetImageFromList(row, col);//get image  from list
            }
            if (incrmt == 2) { NewValue2 = int.Parse(NewValue.ToString()); incrmt = 0; }

            try
            {

                if (NewValue1 > 0 && NewValue2 > 0)
                {
                    if (NewValue1.Equals(NewValue2))
                    {
                        Result = ScoreLbl.GetValue(Label.TextProperty);// Get the value from label text                        
                        ScoreLbl.SetValue(Label.TextProperty, int.Parse(Result.ToString()) + 1);// increase the result that is in label and show it in label                            
                    }
                    NewValue1 = 0; NewValue2 = 0;
                    await Task.Delay(1000);
                    ((BindableObject)sender).SetValue(Image.IsVisibleProperty, false);//set the new  enable property for  card
                    grid.Children.Remove(Removeimg);
                    incrmt = 0;

                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }

        private void DrawImages(int CardNum = 0)
        {
            var i = 0;//row
            var j = 0;//column
            //grid.Children.Clear();
            grid = new Grid();
               foreach (var z in mycards)
            {
                //if (z.isSelectedCard) CardNum = 0;
                //else CardNum = z.CardValue;
                //Create a new card
                image = new Image
                {
                    Source = cardsNames[CardNum],
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    IsEnabled =true,              
                    IsVisible = true,                   
                    ClassId = z.CardId.ToString(),
                    BindingContext = z.CardValue
                };
               
                //Creating TapGestureRecognizers  
                var tapImage = new TapGestureRecognizer();
                //Binding events  
                tapImage.Tapped += TapImage_Tapped;
                //Associating tap events to the image buttons   
                image.GestureRecognizers.Add(tapImage);

                if (j <= 3)
                {
                    grid.Children.Add(image, j, i);
                    GetImages.AddNewIems(i, j, image);//add new image with its coordinate
                    j++;
                }
                else
                {
                    i++;

                    j = 0;
                    GetImages.AddNewIems(i, j, image);//add new image with its coordinate
                    grid.Children.Add(image, j, i);
                    j = 1;
                }
            }
           

        }
    }
}
