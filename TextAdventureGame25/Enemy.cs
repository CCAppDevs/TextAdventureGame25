using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public class Enemy : Actor, IAttackable
    {
        // knowledge
        public bool HasBeenEncountered { get; set; }


        // actions
        public Enemy(string name, int maxHealth, int attackPower) : base(name, maxHealth, attackPower)
        {
            HasBeenEncountered = false;
        }

        public override void RunCombat(Actor opponent)
        {
            bool isInCombat = true;
            HasBeenEncountered = true;

            while (isInCombat)
            {
                Console.WriteLine("What would you like to do: (a)ttack, (r)un?");

                ConsoleKeyInfo keypress;

                keypress = Console.ReadKey(true);

                if (keypress.Key == ConsoleKey.A)
                {
                    // have player attack
                    Console.WriteLine($"{opponent.Name} makes an attack!");
                    opponent.MakeAttack(this, opponent.AttackPower);
                }
                else if (keypress.Key == ConsoleKey.R)
                {
                    // end combat and run away, end the loop early
                    Console.WriteLine($"{opponent.Name} attempts to run away.");
                    isInCombat = false;
                    break;
                }

                // enemy counter
                opponent.TakeDamage(AttackPower);

                // check if either is dead
                if (opponent.IsDead())
                {
                    // cheer for the enemy
                    // exit combat (game over)
                    isInCombat = false;
                }
                else if (IsDead())
                {
                    // give the player a reward
                    // exit combat as a success
                    isInCombat = false;
                }
            }
        }
    }
}
