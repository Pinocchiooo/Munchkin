using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{       
    public class Player
    {
        #region Konstruktor
        public Player(String name = "Munchkin", Gender gender = Gender.male)
        {
            this.name = name;
            this.gender = gender;
            category = Category.Mensch;
            race = Race.Mensch;
            level = 1;
            hands = new List<Equipment>();
            others = new List<Equipment>();
        }
        #endregion

        #region Variablen
        //Private Variablen
        private string name;
        private Gender gender;
        private Category category;
        private Race race;
        private int speed = 4;  //TODO: shoes could help you to run 
        private int equipmentBoni;
        private int numberOfHands = 2;
        private int handsInUse = 0;
        private int level;

        private Equipment headgear;
        private Equipment footwear;
        private List<Equipment> hands;
        private Equipment suit;
        private List<Equipment> others;


        //Datenkapselung: getter für den Gebrauch aus anderen Klassen
        public int Level
        {
            get
            {
                return level;
            }
        }
        public int Speed
        {
            get
            {
                return this.speed;
            }
        } 
        public int Strenght
        {
            get
            {
                return level + equipmentBoni;
            }
        }
        #endregion

        #region Methoden - public
        public void IncreaseLevel(int count)
        {
            for (int i = 0; i < count; i++)
            {
                level++;
            }            
        }
        public void ShowEquipment()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Dein aktuelles Equipment: ");
            Console.Write("Helm: ");
            if (headgear != null)
            {
                Console.WriteLine();
                headgear.Show();
            } else
            {
                Console.WriteLine("nur ein Kopf");
            }

            Console.Write("Schuhwerk: ");
            if (footwear != null)
            {
                Console.WriteLine();
                footwear.Show();
            } else
            {
                Console.WriteLine("zwei Füße");
            }

            Console.Write("Rüstung: ");
            if (suit != null)
            {
                Console.WriteLine();
                suit.Show();

            } else
            {
                Console.WriteLine("Bist du etwa nur in Unterhose?");
            }
            Console.Write("Hände: ");
            if (hands != null)
            {
                Console.WriteLine();
                for(int i = 0; i <= hands.Count - 1; i++)
                {
                    if (hands[i] != null)
                    {
                        hands[i].Show();                    
                    } else
                    {
                        Console.WriteLine("Mit einer leeren Hand lässt sich nicht so leicht kämpfen.");
                    }
                }
            } 

            Console.WriteLine("Weitere: ");
            if (hands != null)
            {
                foreach(Equipment card in others)
                { 
                    card.Show();                    
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public bool UseEquipment(Equipment newEquipment)
        {
            switch (newEquipment.Type) {

                case WearingStyle.body:
                    if (this.suit == null)
                    {
                        this.suit = newEquipment;
                        this.equipmentBoni += suit.Boni;
                        return true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Möchtest du den vorhandenen Rüstungsgegenstand austauschen? [j/n]");
                        Console.ForegroundColor = ConsoleColor.White;

                        this.suit.Show();
                        if (Console.ReadLine() == "j")
                        {
                            this.equipmentBoni -= this.suit.Boni;
                            this.suit = newEquipment;
                            this.equipmentBoni += suit.Boni;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case WearingStyle.feet:
                    {
                        if (this.footwear == null)
                        {
                            this.footwear = newEquipment;
                            this.equipmentBoni += footwear.Boni;
                            return true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Möchtest du den vorhandenen Rüstungsgegenstand austauschen? [j/n]");
                            Console.ForegroundColor = ConsoleColor.White;

                            this.footwear.Show();
                            if (Console.ReadLine() == "j")
                            {
                                this.equipmentBoni -= this.footwear.Boni;
                                this.footwear = newEquipment;
                                this.equipmentBoni += footwear.Boni;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    
                case WearingStyle.head:
                {
                        if (this.headgear == null)
                        {
                            this.headgear = newEquipment;
                            this.equipmentBoni += headgear.Boni;
                            return true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Möchtest du den vorhandenen Rüstungsgegenstand austauschen? [j/n]");
                            Console.ForegroundColor = ConsoleColor.White;

                            this.headgear.Show();
                            if (Console.ReadLine() == "j")
                            {
                                this.equipmentBoni -= this.headgear.Boni;
                                this.headgear = newEquipment;
                                this.equipmentBoni += headgear.Boni;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                case WearingStyle.other:
                    this.others.Add(newEquipment);
                    this.equipmentBoni += newEquipment.Boni;
                    return true;
                case WearingStyle.hands:
                    HandEquipment handEquipment = newEquipment as HandEquipment;
                    if (handEquipment != null) {
                        if (this.numberOfHands - handsInUse - handEquipment.Hands >= 0) 
                        {
                            this.hands.Add(handEquipment);
                            this.equipmentBoni += handEquipment.Boni;
                            this.handsInUse += handEquipment.Hands;
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Du musst erst genügend Hände frei haben.");
                            foreach (HandEquipment card in hands)
                            {
                                card.Show(0);
                            }
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Bitte drücke eine beliebige Taste");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            return false;                            
                        }
                    }
                    return false;
            }
            return false;      
        }
        #endregion
    }
}
