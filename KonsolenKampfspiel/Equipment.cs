using ConsoleTables;
using System;

namespace KonsolenKampfspiel
{
    public class Equipment : Card
    {
        #region Eigenschaften - getter
        public string Name { get; }
        public int Boni { get; }
        public string TypeToShow { get; }
        public WearingStyle Type { get; }
        public int Jewel { get; }
#endregion

        #region Konstruktor
        public Equipment(string name, int boni, WearingStyle type, int jewel, String typeToShow)
        {
            this.TypeToShow = typeToShow;
            this.Name = name;
            this.Boni = boni;
            this.Type = type;
            this.Jewel = jewel;
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
            .AddRow("Typ", TypeToShow)
            .AddRow("Name", Name)
            .AddRow("Boni", Boni)
            .AddRow("Goldstücke", Jewel);

            table.Write(Format.Alternative);
        }

        public override void Show()
        {
            var table =
            new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "Typ", TypeToShow },
                EnableCount = false
            });

            table
            .AddRow("Name", Name)
            .AddRow("Boni", Boni)
            .AddRow("Goldstücke", Jewel);

            table.Write(Format.Alternative);
        }
        #endregion
    }  

    public class HandEquipment: Equipment
    {
        // Diese Klasse erweitert die Equipmentklasse mit der Variablen "hands". 
        #region Variable
        public int Hands { get; }
        #endregion

        #region Konstruktor
        public HandEquipment(string name, int boni, WearingStyle style, string typeToShow, int jewel, int necessaryHands) : base (name, boni, style, jewel, typeToShow)
        {
            Hands = necessaryHands;
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
            .AddRow("Typ", TypeToShow)
            .AddRow("Name", Name)
            .AddRow("Boni", Boni)
            .AddRow("Hände", Hands)
            .AddRow("Goldstücke", Jewel);

            table.Write(Format.Alternative);
        }
        public override void Show()
        {
            var table =
            new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "Typ", TypeToShow },
                EnableCount = false
            });

            table
            .AddRow("Name", Name)
            .AddRow("Boni", Boni)
            .AddRow("Hände", Hands)
            .AddRow("Goldstücke", Jewel);

            table.Write(Format.Alternative);
        }
        #endregion
    }
}
