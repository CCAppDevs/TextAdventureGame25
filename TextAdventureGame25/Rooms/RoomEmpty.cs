using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25.Rooms
{
    public class RoomEmpty : AbstractRoom
    {
        public RoomEmpty(char symbol) : base(symbol)
        {
        }

        public override void OnEnter()
        {
            Console.WriteLine("You see an empty room.");
        }

        public override void OnInteract()
        {
            Console.WriteLine("There is nothing to interact with.");
        }

        public override void OnLeave()
        {
            // nothing to do
            Console.WriteLine("You leave the empty room.");
        }

        public override void ResetRoom()
        {
            // nothing to reset
        }
    }
}
