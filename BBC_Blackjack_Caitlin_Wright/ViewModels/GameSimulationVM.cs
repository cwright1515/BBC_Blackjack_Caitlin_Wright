using BBC_Blackjack_Caitlin_Wright.Models;
using BBC_Blackjack_Caitlin_Wright.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BBC_Blackjack_Caitlin_Wright.ViewModels
{
    public class GameSimulationVM : ViewModelBase
    {
        // GameSimulator _simulator = new GameSimulator();
        #region Properties
        
        private Player player1;

        public Player Player1
        {
            get { return player1; }
            set 
            { 
                player1 = value;
                OnPropertyChanged(nameof(Player1));
            }
        }

        private Player dealer;

        public Player Dealer
        {
            get { return dealer; }
            set { dealer = value;
                OnPropertyChanged(nameof(Dealer));

            }
        }


        #endregion

        #region Commands
        public RelayCommand HitCMD { get; }

        public ICommand StandCMD { get; } 

        #endregion 

        private Deck deck;
        Random r;

        public GameSimulationVM()
        {
            HitCMD = new RelayCommand(func => deal(Player1));
            StandCMD = new RelayCommand(func => stand(Player1));
            startGame();
        }


        private void startGame()
        {
            // new deck at the start of each new game 
            Dealer = new Dealer(0);
            Player1 = new Player(1);
            deck = new Deck();
            r = new Random();
            deck.deckInit();
            initialDeal();

        }

        private void deal(Player player)
        {
            int rInt = r.Next(0, deck.Cards.Count);
            player.deal(deck.Cards[rInt]);
            deck.Cards.RemoveAt(rInt);
            if(player.Total > 21)
            {
                MessageBoxResult result = MessageBox.Show("Bust! Would you like to play again?", "Blackjack Simulator", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        startGame();
                        break;
                }
                        
            }
        }

        private void stand(Player player)
        {
            bool win; 
            int playerRemainder;
            int dealerRemainder;
            if(player.Total < 22)
            {
                playerRemainder = 21 - player.Total;
                dealerRemainder = 21 - Dealer.Total;
                win = playerRemainder < dealerRemainder; 
            }
            else
            {
                win = false; 
            }
            endgame(win);
        }

        private void endgame(bool win)
        {
            if (win)
            {
                MessageBoxResult result = MessageBox.Show($"You won! The dealer had: {Dealer.Total}! Would you like to play again?", "Blackjack Simulator", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        startGame();
                        break;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Bust! The dealer had: {Dealer.Total}! Would you like to play again?", "Blackjack Simulator", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        startGame();
                        break;
                }
            }
        }

        private void initialDeal()
        {
            deal(Player1);
            deal(Dealer);
            deal(Player1);
            deal(Dealer);
            if(Player1.Total > 21)
            {
                startGame();
            }
        }

    }
}
