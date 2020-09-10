using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{
    public class Equipment: Card
    {
        string name;
        int boni;

        public Equipment(string name, int boni)
        {
            this.name = name;
            this.boni = boni;
        }
    }
}
