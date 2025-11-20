using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public class RoomEntrance : IRoom
    {
        public void OnEnter()
        {
            Console.WriteLine("This room contains stairs leading up.");
        }

        public void OnInteract()
        {
            Console.WriteLine("There is nothing to interact with.");
        }

        public void OnLeave()
        {
            Console.WriteLine("You walk into the room beyond.");
        }

        public void ResetRoom()
        {
            // nothing to reset.
        }
    }
}
