using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC_Blackjack_Caitlin_Wright.Models
{
    public class GameSimulator
    {
        private Player dealer;
        private List<Player> players;
        private Deck deck;
        Random r;

        public GameSimulator()
        {
            dealer = new Player(0);
            players = new List<Player>();
            deck = new Deck();
            r = new Random();
            startGame(players.Count);
        }

        private void startGame(int numberOfPlayers)
        {
            // new deck at the start of each new game 
            deck.deckInit();
            players.Add(dealer);

            // set up to allow 1+ players
            for (int i = 1; i < numberOfPlayers + 1; i++)
            {
                players.Add(new Player(i));
            }

            initialDeal();
        }

        private void deal(Player player)
        {
            int rInt = r.Next(0, deck.Cards.Count);
            player.Hand.Add(deck.Cards[rInt]);
            deck.Cards.RemoveAt(rInt);
        }

        private void initialDeal()
        {
            deal(players[1]);
            deal(players[0]);
            deal(players[1]);
            deal(players[0]);
        }

    }
}
