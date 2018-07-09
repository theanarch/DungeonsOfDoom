﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Item
    {
        public Item(string name, int weight, int durability)
        {
            Name = name;
            Weight = weight;
            Durability = durability;
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public int Durability { get; set; }
    }
}
