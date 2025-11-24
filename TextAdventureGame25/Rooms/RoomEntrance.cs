using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25.Rooms
{
    public class RoomEntrance : AbstractRoom
    {
        public RoomEntrance(char symbol) : base(symbol)
        {
        }

        public override void OnEnter()
        {
            Console.WriteLine("This room contains stairs leading up.");
        }

        public override void OnInteract()
        {
            Console.WriteLine("There is nothing to interact with.");
        }

        public override void OnLeave()
        {
            Console.WriteLine("You walk into the room beyond.");
        }

        public override void ResetRoom()
        {
            // nothing to reset.
        }
    }
}
