using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{
    public class Cards
    {
        public DoorCards DoorCards { get; }
        public TreasureCards TreasureCards { get; }
    }
    public class DoorCards : Cards
    {
        public Monster Monster { get; }
    }

    public class TreasureCards : Cards
    {
        public Equipment Equipment { get; }
        public Potion Potion { get; }
    }
    public enum Category
    {
        Mensch,
        Dieb,
        Zauberer,
        Prister,
        Waldlaeufer
    }
    public enum Race
    {
        Mensch,
        Elf,
        Ork,
        Zwerg,
        Gnom,
        Halbling
    }
    public enum Gender
    {
        female,
        male
    }
}
