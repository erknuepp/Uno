namespace Uno.Models
{

    internal abstract class Card
    {
        public Card(string name, int value)
        {
            Name = name;
            Value = value;
        }

        internal string Name { get; init; }
        internal int Value { get; init; }
    }
}
