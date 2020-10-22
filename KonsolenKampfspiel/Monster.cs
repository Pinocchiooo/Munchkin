using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleTables;

namespace KonsolenKampfspiel
{
    public class Monster: Card
    {
        #region  Eigenschaften - getter
        public string Name { get; }
        public int Level { get; }
        public int Treasure { get; }
        public int Increasment { get; }
        #endregion

        #region Konstruktor
        public Monster(string name, int level, int treasure, int increasment)
        {
            this.Name = name;
            this.Level = level;
            this.Treasure = treasure;
            this.Increasment = increasment;
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
            .AddRow("Name", Name)
            .AddRow("Treasure", Treasure)
            .AddRow("Level", Level)
            .AddRow("Increasment", Increasment);

            table.Write(Format.Alternative);
        }

        public override void Show()
        {
            var table =
            new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "Name", Name },
                EnableCount = false
            });

            table
            .AddRow("Treasure", Treasure)
            .AddRow("Level", Level)
            .AddRow("Increasment", Increasment);

            table.Write(Format.Alternative);
        }

        #endregion

        #region Methode - public
        public bool Battle(int strength, Potion[] potion = null)
        {
            if (strength > Level)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
