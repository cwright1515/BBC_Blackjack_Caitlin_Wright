using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC_Blackjack_Caitlin_Wright.Models
{
    public class Dealer : Player
    {
        public Dealer(int ID) : base(ID)
        {
        }

        public override void deal(Card card)
        {
            Hand.Add(card);
            if(Hand.Count < 2)
            {
                TextHand.Add(card.ToString());
            }
            
            Total += card.GetValue();
        }
    }
}
