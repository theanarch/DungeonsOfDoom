﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Weapon : Item
    {

        public Weapon(string name, int weight, int damage, int durability) : base(name, weight, durability)
        {
            Damage = damage;
        }
        public int Damage { get; set; }
    }
}