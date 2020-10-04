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
    //{
    //    //public void Show()
    //    //{
    //    //    WriteTableHorizontally();
    //    //    Console.Write("\t|Name: \t\t|" + name);
    //    //    Console.SetCursorPosition(50, Console.CursorTop); Console.WriteLine("|");
    //    //    Console.Write("\t|Boni: \t|" + boni);
    //    //    Console.SetCursorPosition(50, Console.CursorTop); Console.WriteLine("|");
    //    //    WriteTableHorizontally();
    //    //}
    //    public Suit(string name, int boni, int jewel) : base(name, boni, jewel)
    //    {

    //    }
    //}

    public class HandEquipment: Equipment
    {
        public HandEquipment(string name, int boni, WearingStyle style, int jewel, int necessaryHands) : base (name, boni, style, jewel)
        {

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
