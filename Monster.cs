using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    internal class Monster : Character, IPickupAble
    {
        public Monster(int health, string name, int damage, int armor, int weight, int objMaxCap) : base(name, health, damage, armor, weight, objMaxCap)
        {
        }
    }
}
