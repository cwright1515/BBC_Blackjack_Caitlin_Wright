using BBC_Blackjack_Caitlin_Wright.Models;
using BBC_Blackjack_Caitlin_Wright.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BBC_Blackjack_Caitlin_Wright.ViewModels
{
    public class GameSimulationVM : ViewModelBase
    {
        //private GameSimulator _simulator = new GameSimulator();

        private ObservableCollection<string> dealerHand;

        public ObservableCollection<string> DealerHand
        {
            get { return dealerHand; }
            set 
            { 
                dealerHand = value; 
                OnPropertyChanged(nameof(dealerHand));
            }
        }

        private ObservableCollection<string> playerHand;

        public ObservableCollection<string> PlayerHand
        {
            get { return playerHand; }
            set 
            { 
                playerHand = value; 
                OnPropertyChanged(nameof(playerHand));
            }
        }


        private string playerTotal;

        public string PlayerTotal
        {
            get { return playerTotal; }
            set 
            { 
                playerTotal = value;
                OnPropertyChanged(nameof(playerTotal));
            }
        }

        private string dealerTotal;

        public string DealerTotal
        {
            get { return dealerTotal; }
            set { dealerTotal = value;
                OnPropertyChanged(nameof(dealerTotal));
            }
        }





        public RelayCommand HitCMD { get; }

        public ICommand StandCMD { get; }




        private Player dealer = new Player(0);
        private List<Player> players = new List<Player>();
        private Deck deck = new Deck();
        Random r = new Random();

        public GameSimulationVM()
        {
            DealerHand = new ObservableCollection<string>();
            PlayerHand = new ObservableCollection<string>();
            HitCMD = new RelayCommand(func => deal(players[1]));
            startGame(1);
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

            if (player.getPlayerNumber() == 0)
            {
                DealerHand.Add(deck.Cards[rInt].ToString());
            }
            if (player.getPlayerNumber() != 0)
            {
                PlayerHand.Add(deck.Cards[rInt].ToString());
            }

            if (!(player.getPlayerNumber() == 0 && player.Hand.Count > 1))
            {
                Console.WriteLine($"{player.ToString()} has been dealt {deck.Cards[rInt]}");
            }
            deck.Cards.RemoveAt(rInt);
            PlayerTotal = $"Total: {player.getTotal()}";
        }

        private void initialDeal()
        {
            deal(players[1]);
            deal(players[0]);
            deal(players[1]);
            deal(players[0]);
            PlayerTotal = $"Total: {players[1].getTotal()}";
            DealerTotal = $"Total: {players[0].Hand[0].GetValue()}";
        }

    }
}
