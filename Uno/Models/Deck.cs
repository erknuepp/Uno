namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The deck consists of 108 cards: four each of "Wild" 
    /// and "Wild Draw Four", and 25 each of four colors 
    /// (red, yellow, green, blue). Each color consists of one zero,
    /// two each of 1 through 9, and two each of "Skip", "Draw Two", and "Reverse". 
    /// These last three types are known as "action cards".
    /// </summary>
    internal class Deck
    {
        Stack<Card> cards;

        public Deck()
        {
            cards = new Stack<Card>();
            //Generate Wilds
            for (int i = 0; i < 4; i++)
            {
                cards.Push(new WildCard(isDrawFour: true));
                cards.Push(new WildCard(isDrawFour: false));
            }

            foreach (Color color in Enum.GetValues<Color>())
            {
                cards.Push(new NumberCard(0, color));

                for (int i = 1; i < 10; i++)
                {
                    cards.Push(new NumberCard(i, color));
                    cards.Push(new NumberCard(i, color));
                }

                for (int i = 0; i < 2; i++)
                {
                    cards.Push(new ActionCard(Action.Reverse, color));
                    cards.Push(new ActionCard(Action.Skip, color));
                    cards.Push(new ActionCard(Action.DrawTwo, color));
                }
            }            
        }

        void Shuffle()
        {
            throw new NotImplementedException("Deck.Shuffle - google sort/shuffle for stack");
        }

        /// <summary>
        /// To start a hand, seven cards are dealt to each player, 
        /// and the top card of the remaining deck is flipped over 
        /// and set aside to begin the discard pile. 
        /// The player to the dealer's left plays first unless 
        /// the first card on the discard pile is an action or Wild card (see below). 
        /// On a player's turn, they must do one of the following:
        /// </summary>
        void Deal(ICollection<Player> players)
        {
            
            for (int i = 0; i < 7; i++)
            {
                foreach (var player in players)
                {
                    player.TakeCard(cards.Pop());
                }
            }
        }

        Card Draw()
        {
            return cards.Pop();
        }
    }
}
