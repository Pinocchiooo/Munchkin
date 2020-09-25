using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace KonsolenKampfspiel
{
    public abstract class Card
    {
        static public List<Card> readDoorCards()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\..\\DoorCards.xml");

            List<Card> cards = new List<Card>();

            foreach (XmlNode node in doc.DocumentElement)
            {
                if (node.Name == "Monster")
                {
                    string monsterName = "";
                    int monsterLevel = 0;
                    int monsterTreasure = 0;
                    int monsterIncreasement = 0;

                    foreach (XmlNode child in node.ChildNodes)
                    {
                        switch (child.Name) {
                            case "Name":
                                monsterName = child.InnerText;
                                break;
                            case "Level":
                                monsterLevel = Convert.ToInt32(child.InnerText);
                                break;
                            case "Treasure":
                                monsterTreasure = Convert.ToInt32(child.InnerText);
                                break;
                            case "Increasment":
                                monsterIncreasement = Convert.ToInt32(child.InnerText);
                                break;
                            default:
                                break;
                        }
                    }
                    if (monsterName != "" && monsterLevel != 0 && monsterTreasure != 0 && monsterIncreasement != 0)
                    {
                        Card monster = new Monster(monsterName, monsterLevel, monsterTreasure, monsterIncreasement);
                        cards.Add(monster);
                    }
                    else
                    {
                        throw new System.Exception("Die XML Datei konnte nicht ordnungsgemäß eingelesen werden. Bitte überprüfe, ob die XML datei richtige Werte führt.");
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
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\..\\TreasureCards.xml");

            List<Card> cards = new List<Card>();

            foreach (XmlNode node in doc.DocumentElement)
            {
                if (node.Name == "Equipment")
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name == "Suit")
                        {
                            string suitName = "";
                            int suitBoni = 0;
                            foreach (XmlNode grandson in child)
                            {
                                switch (grandson.Name)
                                {       
                                    case "Name":
                                        suitName = grandson.InnerText;
                                        break;
                                    case "Boni":
                                        //Console.WriteLine(grandson.)
                                        suitBoni = Convert.ToInt32(grandson.InnerText);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (suitName != "" && suitBoni != 0)
                            {
                                Card suit = new Suit(suitName, suitBoni);
                                cards.Add(suit);
                            }
                            else
                            {
                                throw new System.Exception("Die XML Datei konnte nicht ordnungsgemäß eingelesen werden. Bitte überprüfe, ob die XML datei richtige Werte führt.");
                            }
                        }   
                    }
                }
            }

            ////testing Code
            //foreach (Card card in cards)
            //{
            //    Suit test = card as Suit;
            //    if (test != null)
            //    {
            //        test.Show();
            //    }
            //}
            //Console.WriteLine("Finish!");
            //Console.ReadLine();
            return cards;
        }

        public abstract void Show();
        static public void Shuffle(List<Card> cards)
        {  
 //muss keine Liste zurückgeben, da eine Liste ein Referenztyp ist
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
