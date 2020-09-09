using System;
using System.Globalization;
using System.Collections.Generic;
using System.Xml;

namespace KonsolenKampfspiel
{
    class Program
    {      
        static void Main(string[] args)
        {
            List<Cards> doorCards = readDoorCards();
            List<Cards> treasureCards = readTreasureCards();
            shuffleTreashureCards(treasureCards);
            shuffleDoorCards(doorCards);
            Player player = Salutation();
            Gameplay gameplay = new Gameplay(player, treasureCards, doorCards);
        }

        static List<Cards> readDoorCards()
        {
            XmlReader reader = new XmlTextReader("..\\..\\..\\DoorCards.xml");
            string monsterName = "";
            int monsterLevel = 0;
            int monsterTreasure = 0;
            int monsterIncreasement = 0;
            List<Cards> cards = new List<Cards>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Monster")
                    {
                        switch (reader.Name)
                        {
                            case "Name":
                                monsterName = reader.ReadContentAsString();
                                break;
                            case "Level":
                                monsterLevel = reader.ReadContentAsInt();
                                break;
                            case "Treasure":
                                monsterTreasure = reader.ReadContentAsInt();
                                break;
                            case "Increasement":
                                monsterIncreasement = reader.ReadContentAsInt();
                                break;

                        }
                        Cards monster = new Monster(monsterName, monsterLevel, monsterTreasure, monsterIncreasement);
                        cards.Add(monster);
                    }
                }
            }
            foreach (Cards card in cards) {
                Console.WriteLine(card.ToString());

            }

            Console.ReadLine();
            return cards;
        }

        static List<Cards> readTreasureCards()
        {
            throw new NotImplementedException();
        }

        static void shuffleTreashureCards(List<Cards> cards)
        {
            Random random = new Random();

            for (int t = 0; t < cards.Count; t++)
                {
                    Cards tmp = cards[t];                
                int r = random.Next(t, cards.Count);
                    cards[t] = cards[r];
                    cards[r] = tmp;
                }
        }

        static void shuffleDoorCards(List<Cards> cards)
        {
            Random random = new Random();

            for (int t = 0; t < cards.Count; t++)
            {
                Cards tmp = cards[t];
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
