using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public abstract class Actor : IAttackable, ICombat
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Level { get; set; }
        public int AttackPower { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        // TODO: add inventory slots (items, weapons, armor)

        public Actor(string name, int maxHealth, int attackPower)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Level = 1;
            AttackPower = attackPower;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }

        public bool TakeDamage(int amount)
        {
            Health = Health - amount;

            // clamp the value to 0-MaxHealth
            if (Health < 0)
            {
                Health = 0;
            }
            else if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            return true;
        }

        public virtual bool MakeAttack(Actor target)
        {
            Console.WriteLine($"{Name} makes a wild attack at {target.Name}.");

            return target.TakeDamage(AttackPower);
        }
    }
}
