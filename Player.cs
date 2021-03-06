﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Player : Character
    {
        public Player(int health, int x, int y, int damage, int armor, int weight, int objMaxCap) : base("Player", health, damage, armor, weight, objMaxCap)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Inventory { get; set; } = 0;
        public int Capacity { get; set; }

        //public void AddToBackpack(Item item)
        //{
        //    switch (item)
        //    {
        //        case Weapon w: this.Damage += w.Damage; break;
        //        case Consumable c: this.Health += c.Effect; break;
        //        case Armor a: this.Armor += a.DamageReduction; break;
        //        default: break;
        //    }
        //    backpack.Add(item);
        //}
    }
}
