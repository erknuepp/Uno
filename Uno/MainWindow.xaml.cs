namespace Uno
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Deck _deck;
        private DiscardPile _discardPile;
        ICollection<Player> _players;
        IEnumerator<Player> _playersEnumerator;
        private int _round = 1; //TODO See how to bind this to a label so it auto updates

        public MainWindow()
        {
            InitializeComponent();

            _deck = new Deck();
            _deck.Shuffle();
            _discardPile = new DiscardPile();
            _players = new LinkedList<Player>();
            _playersEnumerator = _players.GetEnumerator();
        }

        private void PlayGameButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            //Create players 
            //Start with 2 players and see if we have time for more
            //     (involves reversing player list or direction of play)
            var item = NumberOfPlayersComboBox.SelectedValue as ComboBoxItem;
            int numberOfPlayers = Convert.ToInt32(item.Content);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                _players.Add(new Player($"Player {i + 1}"));
            }

            //Deal cards
            _deck.Deal(_players);

            //Flip fist card to discard pile
            var firstCard = _deck.Draw();
            _discardPile.AddCard(firstCard);

            if (firstCard.GetType() == typeof(WildCard))
            {
                //TODO Player gets to pick any color and has to play a card on that color
                //or just let them play any card?
            }

            //Determine of first card flipped requires an action
            if (firstCard.GetType() == typeof(ActionCard))
            {
                //TODO Add logic if first card is action card
                //((ActionCard)firstCard).TakeAction(); //TODO rethink implementation
                if (((ActionCard)firstCard).Action == Action.DrawTwo)
                {
                    //Add two cards to players hand, MoveNext
                }
                else if (((ActionCard)firstCard).Action == Action.Skip)
                {
                    //MoveNext
                }
                else if (((ActionCard)firstCard).Action == Action.Reverse)
                {
                    //MoveNext
                }
                else if (((ActionCard)firstCard).Action == Action.DrawFour)
                {
                    //return card to deck, shuffle, flip top card
                }
            }

            //Update UI 
            RoundLabel.Content = "Round " + _round;
            DiscardPileLabel.Content = "Discard Pile: " + _discardPile.LastCardPlayed();
            PlayerNameLabel.Content = _players.First().Name + " Play A Card: ";
            HandComboBox.ItemsSource = _players.First().GetHand().Select(x => x.Name);


            while (!CanPlay(firstCard, _players.First().GetHand()))
            {
                _players.First().TakeCard(_deck.Draw());
            }

        }

        /// <summary>
        /// Check that the player has a playable card in their hand
        /// </summary>
        /// <param name="card"></param>
        /// <param name="getHand"></param>
        /// <returns>bool</returns>
        private bool CanPlay(Card card, IList<Card> hand)
        {
            var canPlay = false;

            var cardType = card.GetType();
            var cardBaseType = cardType.BaseType;

            //if card is color card look for those
            if (cardType != typeof(WildCard) && cardBaseType != typeof(WildCard))
            {
                if (cardType == typeof(NumberCard))
                {
                    foreach (Card cardInHand in hand)
                    {
                        var cardInHandType = cardInHand.GetType();
                        var cardInHandBaseType = cardInHandType.BaseType;

                        if (cardInHandType == typeof(NumberCard))
                        {
                            if (((ColorCard)cardInHand).Color == ((ColorCard)card).Color)
                            {
                                canPlay = true;
                                break;
                            }
                            else if (((NumberCard)cardInHand).Number == ((NumberCard)card).Number)
                            {
                                canPlay = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Card cardInHand in hand)
                    {
                        var cardInHandType = cardInHand.GetType();
                        var cardInHandBaseType = cardInHandType.BaseType;

                        if (cardInHandType == typeof(ActionCard))
                        {
                            if (((ColorCard)cardInHand).Color == ((ColorCard)card).Color)
                            {
                                canPlay = true;
                                break;
                            }
                            else if (((ActionCard)cardInHand).Action == ((ActionCard)card).Action)
                            {
                                canPlay = true;
                                break;
                            }
                        }
                    }
                }
            }

            return canPlay; //TODO Needs extensive testing
        }

        private void PlayCardButton_Click(object sender, RoutedEventArgs e)
        {
            _playersEnumerator = _players.GetEnumerator();
            _playersEnumerator.MoveNext();
            var currentPlayer = _playersEnumerator.Current;
            var cardName = HandComboBox.SelectedItem as string;
            var hand = currentPlayer.GetHand();
            var card = hand.Single(x => x.Name == cardName);

            var discard = hand.Remove(card);
            if (discard)
            {
                _discardPile.AddCard(card);
                DiscardPileLabel.Content = "Discard Pile: " + _discardPile.LastCardPlayed();
            }
            else
            {
                MessageBox.Show("Something went terribly wrong! Head for the hills!!!");
            }


            //TODO somehow need to pop the right card from the hand and push to the discard pile.....
            //might be better to bind actual cards to the
            //***combobox and display the name somehow***
            //Note there should probably be a redunacy check to make sure the total is 108 cards
            //_discardPile.AddCard(HandComboBox.SelectedItem
            //Get players enumeration
            //_playersEnumerator = _players.GetEnumerator();
            //_playersEnumerator.MoveNext();

            //TODO Check if player has a car they can play or draw
            //throw new NotImplementedException("PlayCardButton_Click");

            //TODO if a play plays their last card tally up the score:
            //Number cards count their face value, all action cards count 20,
            //and Wild and Wild Draw Four cards count 50.
            //If a Draw Two or Wild Draw Four card is played to go out,
            //the next player in the sequence must draw the appropriate number of cards before the score is tallied.
        }
    }
}
