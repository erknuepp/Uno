namespace Uno
{

    internal class NumberCard : ColorCard
    {
        internal int Number { get; init; }
        public NumberCard(int number, Color color, string name) : base(color, name, number)
        {
            Number = number;
        }
    }
}
