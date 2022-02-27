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
            _playersEnumerator = _players.GetEnumerator();
            _playersEnumerator.MoveNext();
            var currentPlayer = _playersEnumerator.Current;

            RoundLabel.Content = "Round " + _round;
            DiscardPileLabel.Content = "Discard Pile: " + _discardPile.LastCardPlayed().Name;
            PlayerNameLabel.Content = currentPlayer.Name + " Play A Card: ";
            HandComboBox.ItemsSource = currentPlayer.GetHand().Select(x => x.Name);

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
            else if (cardType == typeof(WildCard) || cardBaseType == typeof(WildCard))
            {
                canPlay = true;
            }

            return canPlay; //TODO Needs extensive testing
        }

        private bool ValidPlay(Card card, Card lastCardPlayed)
        {
            var cardType = card.GetType();
            var lastCardPlayedType = lastCardPlayed.GetType();

            if (cardType == typeof(WildCard) || cardType.BaseType == typeof(WildCard))
            {
                //TODO check if they have any other valid cards if it is a draw for
                //      or introduce concept of challenge
                return true;
            }
            if (cardType == typeof(NumberCard))
            {
                if (lastCardPlayedType == typeof(NumberCard))
                {
                    if (((ColorCard)lastCardPlayed).Color == ((ColorCard)card).Color)
                    {
                        return true;
                    }
                    else if (((NumberCard)lastCardPlayed).Number == ((NumberCard)card).Number)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (lastCardPlayedType == typeof(ActionCard))
                {
                    if (((ColorCard)lastCardPlayed).Color == ((ColorCard)card).Color)
                    {
                        return true;
                    }
                    else if (((ActionCard)lastCardPlayed).Action == ((ActionCard)card).Action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void PlayCardButton_Click(object sender, RoutedEventArgs e)
        {
            var currentPlayer = _playersEnumerator.Current;
            var cardName = HandComboBox.SelectedItem as string;
            var hand = currentPlayer.GetHand();
            var card = hand.Single(x => x.Name == cardName);
            bool discardIsValid = false;
            if (ValidPlay(card, _discardPile.LastCardPlayed()))
            {
                discardIsValid = hand.Remove(card);
            }
            else
            {
                return;
            }
            if (discardIsValid)
            {
                _discardPile.AddCard(card);
                _playersEnumerator.MoveNext();
                currentPlayer = _playersEnumerator.Current;
                var lastCardPlayed = _discardPile.LastCardPlayed();
                DiscardPileLabel.Content = "Discard Pile: " + lastCardPlayed.Name;
                PlayerNameLabel.Content = currentPlayer.Name + " Play A Card: ";
                HandComboBox.ItemsSource = currentPlayer.GetHand().Select(x => x.Name);
                while (!CanPlay(lastCardPlayed, currentPlayer.GetHand()))
                {
                    currentPlayer.TakeCard(_deck.Draw());
                }
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
