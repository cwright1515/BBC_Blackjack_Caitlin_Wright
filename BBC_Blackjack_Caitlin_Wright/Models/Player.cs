using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC_Blackjack_Caitlin_Wright.Models
{
    public class Player
    {
        private int playerNumber;

        public List<Card> Hand { get; set; }

        public Player(int ID)
        {
            playerNumber = ID;
            Hand = new List<Card>();
        }

        public int getTotal()
        {
            int total = 0;
            foreach(Card card in Hand)
            {
                total += card.GetValue();
            }
            return total;
        }

        public override string ToString()
        {
            return $"Player {playerNumber}";
        }
    }
}
