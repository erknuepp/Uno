namespace Uno
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    using Uno.Models;

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
            //Create players
            var numberOfPlayers = (int)NumberOfPlayersComboBox.SelectedValue;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                _players.Add(new Player($"Player {i + 1}"));
            }

            //Get players enumeration
            _playersEnumerator = _players.GetEnumerator();

            //Deal cards
            _deck.Deal(_players);

            //Flip fist card to discard pile
            var firstCard = _deck.Draw();
            _discardPile.AddCard(firstCard);

            //Determine of first card flipped requires an action
            if(firstCard.GetType() == typeof(ActionCard))
            {
                //TODO Add logic if first card is action card
                ((ActionCard)firstCard).TakeAction();
            }

            //Update UI 
            DiscardPileLabel.Content = "Discard Pile: " + _discardPile.LastCardPlayed();
            PlayerNameLabel.Content = _players.First().Name + " Play A Card: ";            
            HandComboBox.ItemsSource = _players.First().GetHand();
            ((Button)sender).IsEnabled = false;

            //Determine if play has a card to play
            bool canPlay = CanPlay(firstCard, _players.First().GetHand);

            while (!canPlay)
            {
                //TODO draw more cards until a card can be played
            }
            
        }

        /// <summary>
        /// Check that the player has a playable card in their hand
        /// </summary>
        /// <param name="firstCard"></param>
        /// <param name="getHand"></param>
        /// <returns>bool</returns>
        private bool CanPlay(Card firstCard, Func<IList<string>> getHand)
        {
            var canPlay = false;
            var type = firstCard.GetType();
            return canPlay;
        }

        private void PlayCardButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO somehow need to pop the right card from the hand and push to the discard pile.....
            //might be better to bind actual cards to the combobox nd display the name somehow
            //Note there should probably be a redunacy check to make sure the total is 108 cards
            //_discardPile.AddCard(HandComboBox.SelectedItem
            _playersEnumerator.MoveNext();
            var currentPlayer = _playersEnumerator.Current;

            throw new NotImplementedException("PlayCardButton_Click");

            //TODO if a play plays their last card tally up the score:
            //Number cards count their face value, all action cards count 20,
            //and Wild and Wild Draw Four cards count 50.
            //If a Draw Two or Wild Draw Four card is played to go out,
            //the next player in the sequence must draw the appropriate number of cards before the score is tallied.
        }
    }
}
