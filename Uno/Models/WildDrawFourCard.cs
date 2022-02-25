namespace Uno.Models
{
    using System;

    using Uno.Contracts;

    internal class WildDrawFourCard : Card, IActionable
    {
        public WildDrawFourCard(string name = "Wild Draw Four") : base(name)
        {
        }

        public void TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
