﻿namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
