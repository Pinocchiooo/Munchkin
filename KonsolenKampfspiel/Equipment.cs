using System;
using System.Collections.Generic;
using ConsoleTables;

namespace KonsolenKampfspiel
{
    public class Equipment: Card
    {
        public string name { get; }
        public int boni { get; }
        
        public WearingStyle type { get; }
        public int jewel { get; }
        public Equipment(string name, int boni, WearingStyle type, int jewel)
        {
            this.name = name;
            this.boni = boni;
            this.type = type;
            this.jewel = jewel;
        }

        public override void Show(int cardID = 0)
        {
            var table =
            new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "ID", cardID.ToString() },
                EnableCount = false
            });

            table
            .AddRow("Name", name)
            .AddRow("Boni", boni)
            .AddRow("Goldstücke", jewel);

            table.Write(Format.Alternative);
        }
    }

    //public class Suit : Equipment
  

    public class HandEquipment: Equipment
    {
        public int hands { get; }
        public HandEquipment(string name, int boni, WearingStyle style, int jewel, int necessaryHands) : base (name, boni, style, jewel)
        {
            hands = necessaryHands;
        }

        public override void Show(int cardID)
        {
            var table =
            new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "ID", cardID.ToString() },
                EnableCount = false
            });

            table
            .AddRow("Name", name)
            .AddRow("Boni", boni)
            .AddRow("Hände", hands)
            .AddRow("Goldstücke", jewel);

            table.Write(Format.Alternative);
        }
    }

    //public class FootWear: Equipment
    //{
    //    public FootWear(string name, int boni, int jewel) : base (name, boni, jewel)
    //    {

    //    }
    //}

    //public class HeadGear: Equipment
    //{
    //    public HeadGear(string name, int boni, int jewel) : base (name, boni, jewel)
    //    {

    //    }
    //}
    //public class OtherEquipment: Equipment
    //{
    //    public OtherEquipment(string name, int boni, int jewel) : base (name, boni, jewel)
    //    {

    //    }
    //}
}
