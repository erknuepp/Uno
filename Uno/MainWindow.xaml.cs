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

        public MainWindow()
        {
            InitializeComponent();
            
            _deck = new Deck();
            _discardPile = new DiscardPile();
            _game = new Game();
            _players = new List<Player>();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            int numberOfPlayers;
            while (int.TryParse(NumberOfPlayers.Text, out numberOfPlayers))
            {
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    _players.Add(new Player($"Player {i + 1}"));
                }

                _game.Play(numberOfPlayers);
            }
        }
    }
}
