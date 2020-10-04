using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{       
    public class Player
    {
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

        string name;
        Gender gender;

        Category category;
        Race race;
        int speed = 4;  //TODO: shoes could help you to run 
        int equipmentBoni;
        int numberOfHands = 2;
        int handsInUse = 0;

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
        int level;

        Equipment headgear;
        Equipment footwear;
        List<Equipment> hands;
        Equipment suit;
        List<Equipment> others;

        public void IncreaseLevel(int count)
        {
            for (int i = 0; i < count; i++)
            {
                level++;
            }            
        }
        public void ShowEquipment()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dein aktuelles Equipment: ");
            Console.ForegroundColor = ConsoleColor.White;
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
                    Console.WriteLine("Hand " + i + ": ");
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
        }
        public bool UseEquipment(Equipment newEquipment)
        {
            switch (newEquipment.type) {

                case WearingStyle.body:
                    if (this.suit == null)
                    {
                        this.suit = newEquipment;
                        this.equipmentBoni += suit.boni;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Möchtest du den vorhandenen Rüstungsgegenstand austauschen? [j/n]");
                        this.suit.Show();
                        if (Console.ReadLine() == "j")
                        {
                            this.equipmentBoni -= this.suit.boni;
                            this.suit = newEquipment;
                            this.equipmentBoni += suit.boni;
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
                            this.equipmentBoni += footwear.boni;
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Möchtest du den vorhandenen Rüstungsgegenstand austauschen? [j/n]");
                            this.footwear.Show();
                            if (Console.ReadLine() == "j")
                            {
                                this.equipmentBoni -= this.footwear.boni;
                                this.footwear = newEquipment;
                                this.equipmentBoni += footwear.boni;
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
                            this.equipmentBoni += headgear.boni;
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Möchtest du den vorhandenen Rüstungsgegenstand austauschen? [j/n]");
                            this.headgear.Show();
                            if (Console.ReadLine() == "j")
                            {
                                this.equipmentBoni -= this.headgear.boni;
                                this.headgear = newEquipment;
                                this.equipmentBoni += headgear.boni;
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
                    this.equipmentBoni += newEquipment.boni;
                    return true;
                case WearingStyle.hands:
                    HandEquipment handEquipment = newEquipment as HandEquipment;
                    if (handEquipment != null) {
                        if (this.numberOfHands - handsInUse - handEquipment.hands >= 0) 
                        {
                            this.hands.Add(handEquipment);
                            this.equipmentBoni += handEquipment.boni;
                            this.handsInUse += handEquipment.hands;
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Du musst erst genügend Hände frei haben.");
                            foreach (HandEquipment card in hands)
                            {
                                card.Show(0);
                            }
                            return false;                            
                        }
                    }
                    return false;
            }
            return false;      
        } 
       
        //private int CheckFreeHands()
        //{
        //    int freeHands = 0;
        //    foreach(Equipment hand in hands)
        //    {
        //        freeHands++;
        //    }
        //    return freeHands;
        //}

    }
}
