using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace KonsolenKampfspiel
{
    public abstract class Card
    {
        #region Methoden - static public
        // diese Methoden sind aufrufbar, ohne eine Instanz dieser Klasse zu nutzen.
        static public List<Card> ReadDoorCards()
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

        static public List<Card> ReadTreasureCards()
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
                        switch(child.Name)
                        {
                        case "Suit":
                            WearingStyle body = WearingStyle.body;
                            string suitName = "";
                            int suitBoni = 0;
                            int suitJewel = 0;
                            string suitType = "Rüstung";
                            foreach (XmlNode grandson in child)
                            {
                                switch (grandson.Name)
                                {       
                                    case "Name":
                                        suitName = grandson.InnerText;
                                        break;
                                    case "Boni":
                                        suitBoni = Convert.ToInt32(grandson.InnerText);
                                        break;
                                    case "Jewel":
                                        suitJewel = Convert.ToInt32(grandson.InnerText);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (suitName != "" && suitBoni != 0 && suitJewel != 0)
                            {
                                Card suit = new Equipment(suitName, suitBoni, body, suitJewel, suitType);
                                cards.Add(suit);
                            }
                            else
                            {
                                throw new System.Exception("Die XML Datei konnte nicht ordnungsgemäß eingelesen werden. Bitte überprüfe, ob die XML datei richtige Werte führt.");
                            }
                            break;
                         case "Feet":
                                WearingStyle feet = WearingStyle.feet;
                                string feetName = "";
                                int feetBoni = 0;
                                int feetJewel = 0;
                                string feetType = "Schuhe";
                                foreach (XmlNode grandson in child)
                                {
                                    switch (grandson.Name)
                                    {
                                        case "Name":
                                            feetName = grandson.InnerText;
                                            break;
                                        case "Boni":
                                            feetBoni = Convert.ToInt32(grandson.InnerText);
                                            break;
                                        case "Jewel":
                                            feetJewel = Convert.ToInt32(grandson.InnerText);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                if (feetName != "" && feetBoni != 0 && feetJewel != 0)
                                {
                                    Card footGear = new Equipment(feetName, feetBoni, feet, feetJewel, feetType);
                                    cards.Add(footGear);
                                }
                                else
                                {
                                    throw new System.Exception("Die XML Datei konnte nicht ordnungsgemäß eingelesen werden. Bitte überprüfe, ob die XML datei richtige Werte führt.");
                                }
                                break;
                            case "Head":
                                WearingStyle head = WearingStyle.head;
                                string headName = "";
                                int headBoni = 0;
                                int headJewel = 0;
                                string headType = "Kopfbedeckung";
                                foreach (XmlNode grandson in child)
                                {
                                    switch (grandson.Name)
                                    {
                                        case "Name":
                                            headName = grandson.InnerText;
                                            break;
                                        case "Boni":
                                            headBoni = Convert.ToInt32(grandson.InnerText);
                                            break;
                                        case "Jewel":
                                            headJewel = Convert.ToInt32(grandson.InnerText);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                if (headName != "" && headBoni != 0 && headJewel != 0)
                                {
                                    Card headgear = new Equipment(headName, headBoni, head, headJewel, headType);
                                    cards.Add(headgear);
                                }
                                else
                                {
                                    throw new System.Exception("Die XML Datei konnte nicht ordnungsgemäß eingelesen werden. Bitte überprüfe, ob die XML datei richtige Werte führt.");
                                }
                                break;
                            case "Other":
                                WearingStyle other = WearingStyle.other;
                                string otherName = "";
                                int otherBoni = 0;
                                int otherJewel = 0;
                                string otherType = "Sonstiges";
                                foreach (XmlNode grandson in child)
                                {
                                    switch (grandson.Name)
                                    {
                                        case "Name":
                                            otherName = grandson.InnerText;
                                            break;
                                        case "Boni":
                                            otherBoni = Convert.ToInt32(grandson.InnerText);
                                            break;
                                        case "Jewel":
                                            otherJewel = Convert.ToInt32(grandson.InnerText);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                if (otherName != "" && otherBoni != 0)
                                {
                                    Card headgear = new Equipment(otherName, otherBoni, other, otherJewel, otherType);
                                    cards.Add(headgear);
                                }
                                else
                                {
                                    throw new System.Exception("Die XML Datei konnte nicht ordnungsgemäß eingelesen werden. Bitte überprüfe, ob die XML datei richtige Werte führt.");
                                }
                                break;
                            case "Hand":
                                WearingStyle hands = WearingStyle.hands;
                                string handName = "";
                                int handBoni = 0;
                                int necessaryHands = 0;
                                int handJewel = 0;
                                string handType = "Waffen";
                                foreach (XmlNode grandson in child)
                                {
                                    switch (grandson.Name)
                                    {
                                        case "Name":
                                            handName = grandson.InnerText;
                                            break;
                                        case "Boni":
                                            handBoni = Convert.ToInt32(grandson.InnerText);
                                            break;
                                        case "Hands":
                                            necessaryHands = Convert.ToInt32(grandson.InnerText);
                                            break;
                                        case "Jewel":
                                            handJewel = Convert.ToInt32(grandson.InnerText);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                if (handName != "" && handBoni != 0 && necessaryHands != 0)
                                {
                                    Card handStuff = new HandEquipment(handName, handBoni, hands, handType, handJewel, necessaryHands);
                                    cards.Add(handStuff);
                                }
                                else
                                {                                    
                                    throw new System.Exception("Die XML Datei konnte nicht ordnungsgemäß eingelesen werden. Bitte überprüfe, ob die XML datei richtige Werte führt.");
                                }
                                break;
                            default:
                                break;
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
#endregion

        #region abstrakte Methoden

        //Die überladete Methode Show() muss in allen Subklassen definiert werden
        public abstract void Show(int cardID);
        public abstract void Show();

        #endregion
    }
}
