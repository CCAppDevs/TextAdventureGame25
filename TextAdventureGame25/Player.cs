using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public class Player : Actor, IAttackable
    {
        public Player(string name, int maxHealth) : base(name, maxHealth)
        {
        }

        public void TakeDamage(int amount)
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
        }
    }
}
