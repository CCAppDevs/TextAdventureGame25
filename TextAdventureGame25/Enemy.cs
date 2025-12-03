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

        public override bool MakeAttack(Actor target)
        {
            Random rnd = new Random();

            int damageAdditive = rnd.Next(1, AttackPower);

            int attackDamage = AttackPower + damageAdditive;

            if (attackDamage > (AttackPower * 1.5))
            {
                Console.WriteLine($"{Name} gets super lucky and hits you in a vital spot. You take {attackDamage} damage!");
            }
            else
            {
                Console.WriteLine($"{Name} charges at {target.Name} and deals {attackDamage} damage!");
            }

            return target.TakeDamage(attackDamage);
        }
    }
}
