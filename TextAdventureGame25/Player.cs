using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public class Player : Actor, IAttackable
    {
        public int MapX { get; set; }
        public int MapY { get; set; }

        public Player(string name, int maxHealth, int attackPower, int posX, int posY, int mapX, int mapY) : base(name, maxHealth, attackPower)
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
    }
}
