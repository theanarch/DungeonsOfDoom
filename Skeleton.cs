using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Skeleton : Monster
    {
        public Skeleton(int health, string name, int damage, int armor) : base(health, name, damage, armor)
        {

        }

        public override void Fight(Character opponent)
        {
            if (opponent.Damage >= this.Damage*2)
            {
                this.Health = 0;
            }
            else
            {
                base.Fight(opponent);
            }
        }
    }
}
