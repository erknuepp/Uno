namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class NumberCard : ColorCard
    {
        private readonly int number;
        public NumberCard(int number, Color color) : base(color)
        {
            this.number = number;
        }
    }
}
