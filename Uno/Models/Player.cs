namespace Uno.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Player
    {
        public string Name { get; init; }
        public int Score { get; set; }
        public Player(string name)
        {
            Name = name;
        }
        void PlayCard()
        {

        }
    }
}
