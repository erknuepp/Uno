namespace Uno
{

    internal class ColorCard : Card
    {
        internal Color Color { get; init; }

        public ColorCard(Color color, string name, int value) : base(name, value)
        {
            Color = color;
        }
    }
}
