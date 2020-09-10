using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace KonsolenKampfspiel
{
    public class Card
    {
        static public List<Card> readDoorCards()
        {
            XmlReader reader = new XmlTextReader("..\\..\\..\\DoorCards.xml");
            string monsterName = "";
            int monsterLevel = 0;
            int monsterTreasure = 0;
            int monsterIncreasement = 0;
            List<Card> cards = new List<Card>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Name":
                            if (reader.Read())
                            {
                                monsterName = reader.Value;
                            }
                            break;
                        case "Level":
                            if (reader.Read())
                            {
                                monsterLevel = Convert.ToInt32(reader.Value.Trim());
                            }

                            break;
                        case "Treasure":
                            if (reader.Read())
                            {
                                monsterTreasure = Convert.ToInt32(reader.Value.Trim());
                            }
                            break;
                        case "Increasment":
                            if (reader.Read())
                            {
                                monsterIncreasement = Convert.ToInt32(reader.Value.Trim());
                            }

                            //TODO: programm this clean!
                            Card monster = new Monster(monsterName, monsterLevel, monsterTreasure, monsterIncreasement);
                            cards.Add(monster);
                            break;

                    }
                }
            }
            ////testing Code
            //foreach (Card card in cards)
            //{
            //    Monster test = card as Monster;
            //    if (test != null)
            //    {
            //        test.ShowMonster();
            //    }

            //}
            //Console.WriteLine("Finish!");
            //Console.ReadLine();
            return cards;
        }

        static public List<Card> readTreasureCards()
        {
            XmlReader reader = new XmlTextReader("..\\..\\..\\TreasureCards.xml");
            string equipmentName = "";
            int equipmentBoni = 0;
            List<Card> cards = new List<Card>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Name":
                            if (reader.Read())
                            {
                                equipmentName = reader.Value;
                            }
                            break;
                        case "Boni":
                            if (reader.Read())
                            {
                                equipmentBoni = Convert.ToInt32(reader.Value.Trim());
                            }

                            //TODO: programm this clean!
                            Card monster = new Equipment(equipmentName,equipmentBoni);
                            cards.Add(monster);
                            break;

                    }
                }
            }
            return cards;
        }

        //muss keine Liste zurückgeben, da eine Liste ein Referenztyp ist
        static public void Shuffle(List<Card> cards)
        {
            Random random = new Random();

            for (int t = 0; t < cards.Count; t++)
            {
                Card tmp = cards[t];
                int r = random.Next(t, cards.Count);
                cards[t] = cards[r];
                cards[r] = tmp;
            }
        }
    }
}
