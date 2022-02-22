﻿namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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

        void Deal(ICollection<Player> players)
        {

        }

        Card Draw()
        {
            return cards.Pop();
        }
    }
}
