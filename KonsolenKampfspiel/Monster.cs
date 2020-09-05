using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{
    public class Monster
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
