using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Armor : Item
    {
        public Armor(string name, int weight, int damageReduction, int durability, int objMaxCap) : base(name, weight, durability, objMaxCap)
        {
            DamageReduction = damageReduction;
        }
        public int DamageReduction { get; set; }
    }
}
