using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Weapon : Item
    {

        public Weapon(string name, int weight, int damage, int durability, int objMaxCap) : base(name, weight, durability, objMaxCap)
        {
            Damage = damage;
        }
        public int Damage { get; set; }
    }
}