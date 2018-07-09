using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Character
    {
        public Character(int health, int damage, int armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }
}
