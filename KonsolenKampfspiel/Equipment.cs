using System;
using System.Collections.Generic;

namespace KonsolenKampfspiel
{
    public class Equipment: Card
    {
        public string name { get; }
        public int boni { get; }
        //public int hands { get; }
        public Equipment(string name, int boni)
        {
            this.name = name;
            this.boni = boni;
        }

        public void ShowCard()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Boni: " + boni);
        }
    }

    public class Suit: Equipment
    {
        public void Show()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Boni: " + boni);
        }
        public Suit(string name, int boni) : base (name, boni)
        {
           
        }
    }
}
