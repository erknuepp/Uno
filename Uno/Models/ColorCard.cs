namespace Uno.Models
{

    internal class ColorCard : Card
    {
        Color Color { get; init; }

        public ColorCard(Color color, string name) : base(name)
        {
            Color = color;
        }
    }
}
