using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC_Blackjack_Caitlin_Wright.Models
{
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int playerNumber;
                

        public List<Card> Hand { get; set; }

        public Player(int ID)
        {
            playerNumber = ID;
            Hand = new List<Card>();
            TextHand = new ObservableCollection<string>();
            Total = 0; 
        }

        private ObservableCollection<string> textHand;

        public ObservableCollection<string> TextHand
        {
            get { return textHand; }
            set { textHand = value;
                OnPropertyChanged(nameof(TextHand));

            }
        }

        private int total;

        public int Total
        {
            get { return total; }
            set 
            { 
                total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        public int getPlayerNumber()
        {
            return playerNumber;
        }

        public override string ToString()
        {
            return $"Player {playerNumber}";
        }

        public virtual void deal(Card card)
        {
            Hand.Add(card);
            TextHand.Add(card.ToString());
            Total += card.GetValue();
        }
    }
}
