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

        public RoomMonster(char symbol, Enemy enemy, ConsoleColor color) : base(symbol, color)
        {
            EncounteredEnemy = enemy;
        }

        public override void OnEnter()
        {
            if (EncounteredEnemy.IsDead())
            {
                Console.WriteLine($"There is a dead {EncounteredEnemy.Name} on the floor.");
            } 
            else
            {
                Console.WriteLine($"A wild {EncounteredEnemy.Name} appears!");
                GameInstance.RunCombat(GameInstance.PlayerCharacter, EncounteredEnemy);
            }
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
