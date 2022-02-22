namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Player
    {
        private IList<Card> _cards;
        internal string Name { get; init; }
        internal int Score { get; set; }

        public Player(string name)
        {
            _cards = new List<Card>();
            Name = name;
        }

        internal Card PlayCard(int position)
        {
            return _cards[position];
        }

        internal void TakeCard(Card card)
        {
            _cards.Add(card);
        }
    }
}
