using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MinnespelApp
{
    public  class Game:Player
    {
        private int NumOfCards { get; set; }
        public Game(int numOfCards,string name, string playerId) : base(name, playerId)
        {
            NumOfCards = numOfCards;
        }
        // init data

        public List<Card> GetCards()
        {
            // randomly init data for the cards 

            Random rand = new Random();

            List<Card> listofCards = new List<Card>();

            for (var i = 1; i <= NumOfCards; i++)
                listofCards.Add(new Card
                {
                    CardId = i,
                    IsSelectedCard = true,
                    CardValue = rand.Next(1, NumOfCards),
                    IsVisibleImage = true,

                });


            return listofCards;
            //return new List<Card>(){

            //new Card() {
            //        CardId=1, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    },
            //    new Card()
            //    {
            //         CardId=2, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    },
            //     new Card()
            //    {
            //         CardId=3, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    },
            //    new Card()
            //    {
            //         CardId=4, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    },
            //     new Card()
            //    {
            //         CardId=5, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    },
            //    new Card()
            //    {
            //         CardId=6, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    },
            //     new Card()
            //    {
            //         CardId=7, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    },
            //    new Card()
            //    {
            //         CardId=8, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    },
            //     new Card()
            //    {
            //         CardId=9, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    },
            //    new Card()
            //    {
            //         CardId=10, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    }, new Card()
            //    {
            //         CardId=11, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    },
            //    new Card()
            //    {
            //         CardId=12, isSelectedCard=true, CardValue=rand.Next(1,10), isVisibleImage=true
            //    }
            //};



        }

        

       
    }

  }
