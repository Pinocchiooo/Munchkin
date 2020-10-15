using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleTables;

namespace KonsolenKampfspiel
{
    public class Monster: Card
    {
        #region Variablen - public
        public string name;
        public int level;
        public int treasure;
        public int increasment;
        #endregion

        #region Konstruktor
        public Monster(string name, int level, int treasure, int increasment)
        {
            this.name = name;
            this.level = level;
            this.treasure = treasure;
            this.increasment = increasment;
        }
        #endregion

        #region Methoden - Definition der abstrakten Methoden aus der Basisklasse
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

        public override void Show()
        {
            var table =
            new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "Name", name },
                EnableCount = false
            });

            table
            .AddRow("Treasure", treasure)
            .AddRow("Level", level)
            .AddRow("Increasment", increasment);

            table.Write(Format.Alternative);
        }

        #endregion

        #region Methode - public
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
        #endregion
    }
}
