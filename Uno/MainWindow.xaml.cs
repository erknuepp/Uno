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
        Game _game = new Game();
        ICollection<Player> players;
        public MainWindow()
        {
            InitializeComponent();
            players = new List<Player>();

        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            _game.Play();
        }
    }
}
