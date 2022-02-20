namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// To start a hand, seven cards are dealt to each player, 
    /// and the top card of the remaining deck is flipped over 
    /// and set aside to begin the discard pile. 
    /// The player to the dealer's left plays first unless 
    /// the first card on the discard pile is an action or Wild card (see below). 
    /// On a player's turn, they must do one of the following:
    /// </summary>
    internal class Hand
    {
        ICollection<Card> _cards = new List<Card>();

        public Hand(ICollection<Card> cards)
        {
            _cards = cards;
        }
    }
}
