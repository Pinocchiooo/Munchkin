using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{
    public class Cards
    {
        public Cards()
        {
        }
       
    }
    //public class DoorCards : Cards
    //{
    //    public enum DoorCardType
    //    {
    //        Monster monster 
    //    }
    //    public Monster monster { get; }
    //    private DoorCardType cardType;

    //    public DoorCards(DoorCardType cardType)
    //    {
    //        this.cardType = cardType;
    //    }
    //}

    //public class TreasureCards : Cards
    //{
    //    public Equipment Equipment { get; }
    //    public Potion Potion { get; }
    //}
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
