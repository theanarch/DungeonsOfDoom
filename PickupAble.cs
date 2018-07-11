using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    interface IPickupAble
    {
        string Name { get; }
        int Weight { get; }
        /*
         * Vad som endast behövs av objektet för att ta upp en grej
         */

        //int CurerentWeight { get; set; }
        //int ObjMaxCap { get; }
        //List<IPickupAble> Backpack { get; }
        //void PickUp(IPickupAble pickupAble);
    }
}
