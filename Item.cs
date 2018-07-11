using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Item : IPickupAble
    {
        public Item(string name, int weight, int durability, int objMaxCap)
        {
            Name = name;
            Weight = weight;
            Durability = durability;
            ObjMaxCap = objMaxCap;
            CurerentWeight = 0;
        }

        public string Name { get; set; }
        public int Durability { get; set; }
        public int Weight { get; private set; }  // private kan ändå användas i konstruktorn
        public int CurerentWeight { get; set; }
        public int ObjMaxCap { get; private set; }
        public List<IPickupAble> Backpack { get; }


        public void PickUp(IPickupAble pickupAble)
        {
            if (pickupAble.Weight + this.CurerentWeight <= this.ObjMaxCap)
            {
                Backpack.Add(pickupAble);
            }
        }

        public string AllShit()
        {
            string allItems = "";
            foreach (var item in Backpack)
            {
                allItems += item.ToString();
            }
            return allItems;
        }
    }
}
