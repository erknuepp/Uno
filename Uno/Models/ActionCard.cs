namespace Uno.Models
{
    using System;

    using Uno.Contracts;

    internal class ActionCard : ColorCard, IActionable
    {
        const int value = 20;
        internal Action Action { get; init; }

        public ActionCard(Action action , Color color, string name) : base(color, name, value)
        {
            Action = action;
        }

        public void TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
