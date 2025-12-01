using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25.Rooms
{
    public class RoomLoot : AbstractRoom
    {
        public int GoldReward { get; private set; }

        public RoomLoot(char symbol, int gold) : base(symbol, ConsoleColor.Magenta)
        {
            GoldReward = gold;
        }

        public override void OnEnter()
        {
            Console.WriteLine("You enter a room with a chest inside!");
        }

        public override void OnInteract()
        {
            Console.WriteLine($"You find inside the chest {GoldReward} gold!");
            // TODO: add code to give the player some gold
            GoldReward = 0;
        }

        public override void OnLeave()
        {
        }

        public override void ResetRoom()
        {
            GoldReward = 10;
        }

        public override bool LookAtRoom(Actor searcher)
        {
            throw new NotImplementedException();
        }
    }
}
