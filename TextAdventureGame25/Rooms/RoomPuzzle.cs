using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25.Rooms
{
    public class RoomPuzzle : AbstractRoom
    {
        public RoomPuzzle(char symbol) : base(symbol)
        {
        }

        public override bool LookAtRoom(Actor searcher)
        {
            throw new NotImplementedException();
        }

        public override void OnEnter()
        {
            Console.WriteLine("You encounter a puzzling puzzle.");
        }

        public override void OnInteract()
        {
            Console.WriteLine("You get confused...");
        }

        public override void OnLeave()
        {
            Console.WriteLine("You leave the puzzle room.");
        }

        public override void ResetRoom()
        {
        }
    }
}
