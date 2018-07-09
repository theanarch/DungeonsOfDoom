﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Monster : Character
    {
        public Monster(int health, string name, int damage, int armor) : base(health, damage, armor)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
