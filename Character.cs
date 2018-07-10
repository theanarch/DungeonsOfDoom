using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Character
    {
        public Character(int health, int damage, int armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        private int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value >= 0)
                    health = value;
            }
        }
        private int damage;
        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                if (value >= 0)
                    damage = value;
            }
        }

        private int armor;
        public int Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value >= 0)
                    armor = value;
                else
                    armor = 0;
            }
        }

        public virtual void Fight(Character opponent)
        {
            if (opponent.Armor > 0)
                opponent.Armor -= this.Damage;
            else
                opponent.Health -= this.Damage;
        }
    }
}
