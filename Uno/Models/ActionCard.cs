namespace Uno.Models
{
    using System;

    using Uno.Contracts;

    internal class ActionCard : ColorCard, IActionable
    {
        Action Action { get; init; }

        public ActionCard(Action action , Color color, string name) : base(color, name)
        {
            Action = action;
        }

        public void TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
