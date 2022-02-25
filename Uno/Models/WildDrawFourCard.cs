namespace Uno.Models
{
    using System;

    using Uno.Contracts;

    internal class WildDrawFourCard : Card, IActionable
    {
        const int value = 50;

        public WildDrawFourCard(string name = "Wild Draw Four") : base(name, value)
        {
        }

        public void TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
