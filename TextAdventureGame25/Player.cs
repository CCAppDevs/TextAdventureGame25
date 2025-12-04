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

        public override bool MakeAttack(Actor target)
        {
            Random rnd = new Random();

            int damageAdditive = rnd.Next(1, AttackPower);

            int attackDamage = AttackPower + damageAdditive;

            if (attackDamage > (AttackPower * 1.5))
            {
                Console.WriteLine($"{Name} channels their inner fury and hits for massive damage! {target.Name} takes {attackDamage} damage.");
            }
            else
            {
                Console.WriteLine($"{Name} makes a wild attack at {target.Name}. {target.Name} takes {attackDamage} damage.");
            }

            return target.TakeDamage(attackDamage);
        }

        public void HealPlayer(int amount)
        {
            Health = Health + amount;

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
