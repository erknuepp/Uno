namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
