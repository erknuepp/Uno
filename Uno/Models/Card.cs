namespace Uno.Models
{

    internal abstract class Card
    {
        public Card(string name)
        {
            Name = name;
        }

        internal string Name { get; init; }
    }
}
