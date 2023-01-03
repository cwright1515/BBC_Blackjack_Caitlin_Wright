using BBC_Blackjack_Caitlin_Wright.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC_Blackjack_Caitlin_Wright.ViewModels
{
    public class GameSimulation
    {
        private Player dealer = new Player(0);
        private List<Player> players = new List<Player>();
        private Deck deck = new Deck();

        Random r = new Random();

        public GameSimulation()
        {
            startGame(1);
        }
        
        
        private void startGame(int numberOfPlayers)
        {
            // new deck at the start of each new game 
            deck.deckInit();
            players.Add(dealer);

            // set up to allow 1+ players
            for(int i = 1; i < numberOfPlayers + 1; i++)
            {
                players.Add(new Player(i)); 
            }

            deal(players[1]);
            deal(players[0]);
            deal(players[1]);
            deal(players[0]);
            Console.WriteLine(players[0].getTotal());
            Console.WriteLine(players[1].getTotal());

        }
        private void deal(Player player)
        {
            int rInt = r.Next(0, deck.Cards.Count);
            player.Hand.Add(deck.Cards[rInt]);
            Console.WriteLine($"{player.ToString()} has been dealt {deck.Cards[rInt]}");
            deck.Cards.RemoveAt(rInt);   
        }

        private void stand()
        {

        }

        private void hit()
        {

        }
    }
}
