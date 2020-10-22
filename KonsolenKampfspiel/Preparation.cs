using System;
using System.Globalization;
using System.Collections.Generic;
using System.Xml;

namespace KonsolenKampfspiel
{
    class Preparation
    {      
        static void Main(string[] args)
        {
            NewGame();
        }

        static public void NewGame() {
            List<Card> doorCards = Card.ReadDoorCards();
            List<Card> treasureCards = Card.ReadTreasureCards();
            Card.Shuffle(treasureCards);
            Card.Shuffle(doorCards);
            Player player = Salutation();
            Gameplay gameplay = new Gameplay(player, treasureCards, doorCards);
        }

        static Player Salutation()
        {
            Console.Title = "Munchkin";
            Console.WriteLine("Willkommen Knirps,\nEs sind viele Monster unterwegs. Stelle dich der Herausforderung und erlange als Erster die 10. Stufe indem du sie besiegst.");

            Console.WriteLine("\nWie ist dein Name?");
            String name = Console.ReadLine();
            Console.WriteLine("Bitte wähle außerdem dein Geschlecht. [w/m]");
            string genderKey = Console.ReadLine();
            Gender gender = Gender.male;
            if (genderKey == "w")
            {
                gender = Gender.female;
            }
            else if (genderKey == "m")
            {
                gender = Gender.male;
            } 
            Console.Clear();
            return new Player(name, gender);
        }              
    }
}
