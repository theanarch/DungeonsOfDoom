using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Consumable : Item
    {
        public Consumable(string name, int weight, int durability, int effect) : base(name, weight, durability)
        {
            Effect = effect;
        }
        public int Effect { get; set; }
    }
}
