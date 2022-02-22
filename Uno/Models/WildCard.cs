namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class WildCard : Card
    {
        public bool IsDrawFour { get; init; }
        
        public WildCard(bool isDrawFour):base()
        {
            IsDrawFour = isDrawFour;
        }
    }
}
