namespace Uno.Models
{

    internal class NumberCard : ColorCard
    {
        private readonly int number;
        public NumberCard(int number, Color color, string name) : base(color, name)
        {
            this.number = number;
        }
    }
}
