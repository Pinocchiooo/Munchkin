using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{
    //TODO: Use Categories
    public enum Category
    {
        Mensch,
        Dieb,
        Zauberer,
        Prister,
        Waldlaeufer
    }

    //TODO: Use Races
    public enum Race
    {
        Mensch,
        Elf,
        Ork,
        Zwerg,
        Gnom,
        Halbling
    }

    //TODO: Use Gender
    public enum Gender
    {
        female,
        male
    }

    public enum WearingStyle
    {   head,
        body,
        feet,
        hands,
        other      
    }
}
