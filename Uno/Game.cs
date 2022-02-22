namespace Uno
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The aim of the game is to be the first player to score 500 points, 
    /// achieved (usually over several rounds of play) by being the first to 
    /// play all of one's own cards 
    /// and scoring points for the cards still held by the other players.
    /// </summary>
    internal class Game
    {
        //Defaults to True
        private bool isProcessionClockwise = true;

        const int Winning_Score = 500;

        public Game()
        {

        }

        internal void Play(int numberOfPlayers) 
        { 
            //throw new NotImplementedException(); 
        }
    }
}
