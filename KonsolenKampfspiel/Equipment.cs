using System;
using System.Collections.Generic;

namespace KonsolenKampfspiel
{
    public class Equipment: Card
    {
        string name;
        int boni;
        WearingStyle wearingStyle;

        public Equipment(string name, int boni, WearingStyle wearingStyle, int moreHands= 0)
        {
            this.name = name;
            this.boni = boni;
            this.wearingStyle = wearingStyle;
        }

        public void ShowEquipment()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Boni: " + boni);
        }
    }
}
