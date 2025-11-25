using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public class Player : Actor, IAttackable
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int MapX { get; set; }
        public int MapY { get; set; }

        public Player(string name, int maxHealth, int posX, int posY, int mapX, int mapY) : base(name, maxHealth)
        {
            PosX = posX;
            PosY = posY;
            MapX = mapX;
            MapY = mapY;
        }

        public void MoveDown(int direction)
        {
            PosY += direction;
            if (PosY >= MapY)
            {
                PosY = MapY - 1;
            } 
            else if (PosY < 0)
            {
                PosY = 0;
            }
        }

        public void MoveRight(int direction)
        {
            PosX += direction;
            if (PosX >= MapX)
            {
                PosX = MapX - 1;
            }
            else if (PosX < 0)
            {
                PosX = 0;
            }
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
