using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Ogre : Monster
    {
        public Ogre(int health, string name, int damage, int armor, int weight, int objMaxCap) : base(health, name, damage, armor, weight, objMaxCap)
        {

        }
    }
}
