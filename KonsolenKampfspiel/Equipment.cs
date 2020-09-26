using System;
using System.Collections.Generic;
using ConsoleTables;

namespace KonsolenKampfspiel
{
    public class Equipment: Card
    {
        public string name { get; }
        public int boni { get; }
        //public int hands { get; }
        public Equipment(string name, int boni)
        {
            this.name = name;
            this.boni = boni;
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
            .AddRow("Boni", boni);

            table.Write(Format.Alternative);
        }
    }

    public class Suit: Equipment
    {
        //public void Show()
        //{
        //    WriteTableHorizontally();
        //    Console.Write("\t|Name: \t\t|" + name);
        //    Console.SetCursorPosition(50, Console.CursorTop); Console.WriteLine("|");
        //    Console.Write("\t|Boni: \t|" + boni);
        //    Console.SetCursorPosition(50, Console.CursorTop); Console.WriteLine("|");
        //    WriteTableHorizontally();
        //}
        public Suit(string name, int boni) : base (name, boni)
        {
           
        }
    }
}
