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
        private readonly Game _game;
        ICollection<Player> _players;
        IEnumerator<Player> _playersEnumerator;

        public MainWindow()
        {
            InitializeComponent();
            
            _deck = new Deck();
            _deck.Shuffle();
            _discardPile = new DiscardPile();
            _game = new Game();
            _players = new LinkedList<Player>();
        }

        private void PlayGameButton_Click(object sender, RoutedEventArgs e)
        {
            //int numberOfPlayers;

            //refactor this to a method in an input class???
            //while (int.TryParse(NumberOfPlayersTextBox.Text, out numberOfPlayers))
            //{
                
            //}

            for (int i = 0; i < 2; i++) //update to correct # of players
            {
                _players.Add(new Player($"Player {i + 1}"));
            }
            _playersEnumerator = _players.GetEnumerator();
            //TODO add comments
            _deck.Deal(_players);
            _discardPile.AddCard(_deck.Draw());
            DiscardPileLabel.Content = _discardPile.LastCardPlayed();
            PlayerNameLabel.Content = _players.First().Name + " Play A Card: ";
            HandComboBox.ItemsSource = _players.First().GetHand();
            ((Button)sender).IsEnabled = false;
            throw new NotImplementedException("Handle logic of what happens if first card flipped is an action card.");

            //TODO I think this enumeration should eist outside the click event and next should be called when you click play card somehow.
            //_game.Play(numberOfPlayers);
            //var players = _players.GetEnumerator();
            //while (players.MoveNext())
            //{
            //    //Start the game here

            //}
            
        }

        private void PlayCardButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO somehow need to pop the right card from the hand and push to the discard pile.....
            //might be better to bind actual cards to the combobox nd display the name somehow
            //Note there should probably be a redunacy check to make sure the total cards is 108
            //_discardPile.AddCard(HandComboBox.SelectedItem
            _playersEnumerator.MoveNext();
            throw new NotImplementedException("PlayCardButton_Click");
        }
    }
}
