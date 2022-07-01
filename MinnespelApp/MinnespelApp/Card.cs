using Xamarin.Forms;

namespace MinnespelApp
{
    public class Player {
        public string PlayerId { get; set; }
        public string  Name { get; set; }
       public Player(string name, string playerId)
        {
            Name = name;
            PlayerId = playerId;
        }
    }
    public class Card 
    {
        public int CardId { get; set; }
        public int CardValue { get; set; }
        public bool IsSelectedCard { get; set; }   
        public bool  IsVisibleImage { get; set; }
       

    }
}
