namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ActionCard : ColorCard
    {
        Action Action { get; init; }

        public ActionCard(Action action , Color color, string name) : base(color, name)
        {
            Action = action;
        }

        void TakeAction() 
        {

        }
    }
}
