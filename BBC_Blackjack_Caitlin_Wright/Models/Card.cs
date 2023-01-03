using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC_Blackjack_Caitlin_Wright.Models
{
    public class Card
    {
        private int value;
        private Suit suit;
        private String label;

        public Card(int Value, Suit Suit)
        {
            value = Value;
            suit = Suit;
            convertValToLabel();
        }

        private void convertValToLabel()
        {
            switch (value)
            {
                case 1:
                    label = "Ace";
                    break; 
                case 11:
                    label = "Jack";
                        break;
                case 12:
                    label = "Queen";
                    break;
                case 13:
                    label = "King";
                    break;
                default : label = value.ToString(); break;
            }
        }

        public override string ToString()
        {
            return "Card is the " + label + " of " + suit.ToString();
        }

    }
}
