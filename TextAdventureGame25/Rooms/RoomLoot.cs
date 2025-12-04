using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25.Rooms
{
    public class RoomLoot : AbstractRoom
    {
        public int HealthReward { get; private set; }
        public bool HasConsumed = false;

        public RoomLoot(char symbol, int health) : base(symbol, ConsoleColor.Magenta)
        {
            HealthReward = health;
        }

        public override void OnEnter()
        {
            if (HasConsumed)
            {
                Console.WriteLine("You find an empty chest.");
            } else
            {
                Console.WriteLine("You enter a room with a chest inside!");
                Console.WriteLine("You open the chest and find a health potion!");
                GameInstance.PlayerCharacter.HealPlayer(HealthReward);
                Console.WriteLine($"{GameInstance.PlayerCharacter.Name} has {GameInstance.PlayerCharacter.Health} left.");
                HasConsumed = true;
            }
        }

        public override void OnInteract()
        {
            Console.WriteLine($"You find inside the chest {HealthReward} gold!");
            // TODO: add code to give the player some gold
            HealthReward = 0;
        }

        public override void OnLeave()
        {
        }

        public override void ResetRoom()
        {
            HealthReward = 10;
        }

        public override bool LookAtRoom(Actor searcher)
        {
            throw new NotImplementedException();
        }
    }
}
