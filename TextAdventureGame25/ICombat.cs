using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame25
{
    public interface ICombat
    {
        bool MakeAttack(Actor target, int damage);
        void RunCombat(Actor opponent);
    }
}
