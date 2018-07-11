using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Character : IPickupAble
    {
        public Character(string name, int health, int damage, int armor, int weight, int objMaxCap)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
            Weight = weight;
            ObjMaxCap = objMaxCap;
            CurerentWeight = 0;
        }
        public string Name { get; }
        public int Weight { get; private set; }  // private kan ändå användas i konstruktorn
        public int CurerentWeight { get; set; }
        public int ObjMaxCap { get; private set; }
        public List<IPickupAble> Backpack { get; } = new List<IPickupAble>();
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

        public void PickUp(IPickupAble pickupAble)
        {
            if (pickupAble.Weight + this.CurerentWeight <= this.ObjMaxCap)
            {
                Backpack.Add(pickupAble);
                this.CurerentWeight += pickupAble.Weight;
            }
        }
    }
}
