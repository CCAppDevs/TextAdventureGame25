using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25.Rooms
{
    public class RoomMonster : AbstractRoom
    {
        public Enemy EncounteredEnemy { get; set; }

        public RoomMonster(char symbol, Enemy enemy) : base(symbol)
        {
            EncounteredEnemy = enemy;
        }

        public override void OnEnter()
        {
            Console.WriteLine($"A wild {EncounteredEnemy.Name} appears!");
        }

        public override void OnInteract()
        {
            // TODO: need to add combat here
        }

        public override void OnLeave()
        {
            if (EncounteredEnemy.IsDead())
            {
                Console.WriteLine("You walk away from the carnage.");
            }
            else
            {
                Console.WriteLine($"You run away from {EncounteredEnemy.Name}!");
            }
        }

        public override void ResetRoom()
        {
            // TODO: what should happen here?
        }

        public override bool LookAtRoom(Actor searcher)
        {
            throw new NotImplementedException();
        }
    }
}
