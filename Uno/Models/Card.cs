namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal abstract class Card
    {
        public Card(string name)
        {
            Name = name;
        }

        internal string Name { get; init; }
    }
}
