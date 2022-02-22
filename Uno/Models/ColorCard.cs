namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ColorCard : Card
    {
        Color Color { get; init; }

        public ColorCard(Color color) : base()
        {
            Color = color;
        }
    }
}
