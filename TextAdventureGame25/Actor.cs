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
        public int PosX { get; set; }
        public int PosY { get; set; }

        // TODO: add inventory slots (items, weapons, armor)

        public Actor(string name, int maxHealth)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Level = 1;
            AttackPower = 1;
        }

        public void MoveRight(int spaces)
        {
            PosX += spaces;
            // TODO: look for edge of map, can i move here
        }

        public void MoveDown(int spaces) 
        {
            PosY += spaces;
            // TODO: look for edge of map, can i move here
        }

        public void Teleport(int x, int y)
        {
            PosX = x;
            PosY = y;
            // TODO: does this position exist on the map, can i move here
        }

        public bool IsDead()
        {
            return Health <= 0;
        }
    }
}
