using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25.Rooms
{
    internal class BossRoom : AbstractRoom
    {
        public Enemy Boss { get; set; }

        public BossRoom(char symbol, Enemy enemy) : base(symbol, ConsoleColor.Green)
        {
            Boss = enemy;
        }

        public override void OnEnter()
        {
            Console.WriteLine($"You enter a large chamber. Inside you find {Boss.Name} waiting for you.");
        }

        public override void OnInteract()
        {
            // do boss combat
        }

        public override void OnLeave()
        {
            if (Boss.IsDead())
            {
                Console.WriteLine("You step past the defeated boss into the stairwell below.");
                // TODO: trigger the next map here (in the game class)
                Game currentInstance = Game.GetInstance();

                if (currentInstance == null)
                {
                    throw new Exception("Game instance not found");
                }

                currentInstance.OnExitMap();
            }
            else
            {
                Console.WriteLine("You run away from the boss.");
            }
        }

        public override void ResetRoom()
        {
        }

        public override bool LookAtRoom(Actor searcher)
        {
            throw new NotImplementedException();
        }
    }
}
