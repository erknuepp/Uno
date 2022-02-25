namespace Uno.Models
{

    internal class ColorCard : Card
    {
        Color Color { get; init; }

        public ColorCard(Color color, string name, int value) : base(name, value)
        {
            Color = color;
        }
    }
}
