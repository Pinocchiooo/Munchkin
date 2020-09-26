using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleTables;

namespace KonsolenKampfspiel
{
    public class Monster: Card
    {
        string name;
        int level;
        int treasure;
        int increasment;

        public Monster(string name, int level, int treasure, int increasment)
        {
            this.name = name;
            this.level = level;
            this.treasure = treasure;
            this.increasment = increasment;
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
            .AddRow("Treasure", treasure)
            .AddRow("Level", level)
            .AddRow("Increasment", increasment);

            table.Write(Format.Alternative);
        }


        public bool battle(int strength, Potion[] potion = null)
        {
            if (strength > level)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
