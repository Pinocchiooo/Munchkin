using System;
using System.Collections.Generic;
using ConsoleTables;

namespace KonsolenKampfspiel
{
    public class Equipment : Card
    {
        #region Variablen mit Eigenschaften - getter
        public string name { get; }
        public int boni { get; }
        public string typeToShow { get; }
        public WearingStyle type { get; }
        public int jewel { get; }
#endregion

        #region Konstruktor
        public Equipment(string name, int boni, WearingStyle type, int jewel, String typeToShow)
        {
            this.typeToShow = typeToShow;
            this.name = name;
            this.boni = boni;
            this.type = type;
            this.jewel = jewel;
        }
        #endregion

        #region Methoden - Definition der abstrakten Methoden aus der Basisklasse
        public override void Show(int cardID = 0)
        {
            var table =
            new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "ID", cardID.ToString() },
                EnableCount = false
            });

            table
            .AddRow("Typ", typeToShow)
            .AddRow("Name", name)
            .AddRow("Boni", boni)
            .AddRow("Goldstücke", jewel);

            table.Write(Format.Alternative);
        }

        public override void Show()
        {
            var table =
            new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "Typ", typeToShow },
                EnableCount = false
            });

            table
            .AddRow("Name", name)
            .AddRow("Boni", boni)
            .AddRow("Goldstücke", jewel);

            table.Write(Format.Alternative);
        }
        #endregion
    }  

    public class HandEquipment: Equipment
    {
        // Diese Klasse erweitert die Equipmentklasse mit der Variablen "hands". 
        #region Variable
        public int hands { get; }
        #endregion

        #region Konstruktor
        public HandEquipment(string name, int boni, WearingStyle style, string typeToShow, int jewel, int necessaryHands) : base (name, boni, style, jewel, typeToShow)
        {
            hands = necessaryHands;
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
            .AddRow("Typ", typeToShow)
            .AddRow("Name", name)
            .AddRow("Boni", boni)
            .AddRow("Hände", hands)
            .AddRow("Goldstücke", jewel);

            table.Write(Format.Alternative);
        }
        public override void Show()
        {
            var table =
            new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "Typ", typeToShow },
                EnableCount = false
            });

            table
            .AddRow("Name", name)
            .AddRow("Boni", boni)
            .AddRow("Hände", hands)
            .AddRow("Goldstücke", jewel);

            table.Write(Format.Alternative);
        }
        #endregion
    }
}
