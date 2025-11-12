using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public abstract class Actor
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Level { get; set; }
        public int AttackPower { get; set; }

        // TODO: add inventory slots (items, weapons, armor)

        public Actor(string name, int maxHealth)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Level = 1;
            AttackPower = 1;
        }

        //public void TakeDamage(int amount)
        //{
        //    Health = Health - amount;

        //    // clamp the value to 0-MaxHealth
        //    if (Health < 0)
        //    {
        //        Health = 0;
        //    }
        //    else if (Health > MaxHealth)
        //    {
        //        Health = MaxHealth;
        //    }
        //}
    }
}
