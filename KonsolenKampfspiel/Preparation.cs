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
            List<Card> doorCards = Card.readDoorCards();
            List<Card> treasureCards = Card.readTreasureCards();
            Card.Shuffle(treasureCards);
            Card.Shuffle(doorCards);
            Player player = Salutation();
            Gameplay gameplay = new Gameplay(player, treasureCards, doorCards);
        }

        static Player Salutation()
        {
            Console.Title = "Munchkin";
            Console.WriteLine("Willkommen Knirps,\nEs sind viele Monster unterwegs. Stelle dich der Herausforderung und erlange als ertster die 10. Stufe indem sie besiegst.");
            Console.WriteLine("Um dir deine Handkarten anzusehen drücke einfach \"k\" [k]");
            Console.WriteLine("Eine Rüstungskarte anwenden/ auswechseln [r]");
            Console.WriteLine("Wenn du nicht mehr weißt, wie du steuern kannst, lass dir gerne helfen [h]");


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
