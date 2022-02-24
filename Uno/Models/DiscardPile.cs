namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DiscardPile
    {
        Stack<Card> cards;

        public DiscardPile()
        {
            cards = new Stack<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Push(card);
        }
        
        public string LastCardPlayed()
        {
            return cards.Peek().Name;
        }
    }
}
