using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC_Blackjack_Caitlin_Wright.Models
{
    public class Deck
    {
        private List<Card> Cards;

        public Deck()
        {
            deckInit();
            foreach(Card card in Cards)
            {
                Console.WriteLine(card.ToString());
            }
        }

        private void deckInit()
        {
            Cards = new List<Card>();
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for(int i = 1; i < 14; i++)
                {
                    Card card = new Card(i, suit);  
                    Cards.Add(card);
                }
            }
        }
    }
}
