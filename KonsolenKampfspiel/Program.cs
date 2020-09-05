using System;
using System.Globalization;
using System.Collections.Generic;

namespace KonsolenKampfspiel
{
    class Program
    {      
        static void Main(string[] args)
        {
            List<DoorCards> doorCards = readDoorCards();
            List<TreasureCards> treasureCards = readTreasureCards();
            shuffleTreashureCards(treasureCards);
            shuffleDoorCards(doorCards);
            Player player = Salutation();
            Gameplay gameplay = new Gameplay(player, treasureCards, doorCards);
        }

        static List<DoorCards> readDoorCards()
        {
            throw new NotImplementedException();
        }

        static List<TreasureCards> readTreasureCards()
        {
            throw new NotImplementedException();
        }

        static void shuffleTreashureCards(List<TreasureCards> cards)
        {
            Random random = new Random();

            for (int t = 0; t < cards.Count; t++)
                {
                    TreasureCards tmp = cards[t];                
                int r = random.Next(t, cards.Count);
                    cards[t] = cards[r];
                    cards[r] = tmp;
                }
        }

        static void shuffleDoorCards(List<DoorCards> cards)
        {
            Random random = new Random();

            for (int t = 0; t < cards.Count; t++)
            {
                DoorCards tmp = cards[t];
                int r = random.Next(t, cards.Count);
                cards[t] = cards[r];
                cards[r] = tmp;
            }
        }

        static Player Salutation()
        {
            Console.WriteLine("Willkommen Knirps,\nEs sind viele Monster unterwegs. Stelle dich der Herausforderung und erlange als ertster die 10. Stufe indem sie besiegst.");
            Console.WriteLine("Um dir deine Handkarten anzusehen drücke einfach \"k\" [k]");
            Console.WriteLine("Wenn du nicht mehr weißt, wie steuern kannst, lass dir gerne helfen [h]");
   
            Console.WriteLine("\nWie ist dein Name?");
            String name = Console.ReadLine();
            Console.WriteLine("Bitte wähle außerdem dein Geschlecht. [w/m]");
            string genderKey = Console.ReadLine();
            Gender gender;
            if (genderKey == "w")
            {
                gender = Gender.female;
                return new Player(name, gender);
            }
            else if (genderKey == "m")
            {
                gender = Gender.male;
                return new Player(name, gender);
            } else
            {
                return new Player(name);
            }
        }
    }
}
