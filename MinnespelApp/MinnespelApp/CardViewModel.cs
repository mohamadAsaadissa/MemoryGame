using System.ComponentModel;
using Xamarin.Forms;

namespace MinnespelApp
{
    //that the class implements the INotifyPropertyChanged interface, 
    //which will allow elements of the user interface automatically sync 
    //values with the values of the object properties card.
    public class CardViewModel : INotifyPropertyChanged
    {
         public event PropertyChangedEventHandler PropertyChanged;

        public Card Acard { get; set; }

        public CardViewModel()
        {
            Acard = new Card();
        }

       

        public int CardId
        {
            get { return Acard.CardId; }
            set
            {
                Acard.CardId = value;
                OnPropertyChanged("CardId");
            }
        }

        public int CardValue
        {
            get { return Acard.CardValue; }
            set
            {
                Acard.CardValue = value;
                OnPropertyChanged("CardValue");
            }
        }
        public bool IsVisibleImage
        {
            get { return Acard.IsVisibleImage; }
            set
            {
                Acard.IsVisibleImage = value;
                OnPropertyChanged("IsVisibleImage");
            }
        }
        public bool IsSelectedCard
        {
            get { return Acard.IsSelectedCard; }
            set
            {
                Acard.IsSelectedCard = value;
                OnPropertyChanged("IsSelectedCard");
            }
        }
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        }
    }
   }