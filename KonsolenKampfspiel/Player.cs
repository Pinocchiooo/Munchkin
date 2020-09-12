﻿using System;
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
            hands = new Equipment[2];
            others = new Equipment[10];
        }

        string name;
        Gender gender;

        Category category;
        Race race;

        int strenght
        {
            get
            {
                return level; //TODO: and equipmentpoints
            }
        }
        int level;

        Equipment headgear;
        Equipment footwear;
        Equipment[] hands;
        Equipment suit;
        Equipment[] others;

        public void showEquipment()
        {
            Console.Write("Helm: ");
            if (headgear != null)
            {
                Console.WriteLine();
                headgear.ShowCard();
            } else
            {
                Console.WriteLine("nur ein Kopf");
            }

            Console.Write("Schuhwerk: ");
            if (footwear != null)
            {
                Console.WriteLine();
                footwear.ShowCard();
            } else
            {
                Console.WriteLine("zwei Füße");
            }

            Console.Write("Rüstung: ");
            if (suit != null)
            {
                Console.WriteLine();
                suit.ShowCard();

            } else
            {
                Console.WriteLine("Bist du etwa nur in Unterhose?");
            }
            Console.Write("Hände: ");
            if (hands != null)
            {
                Console.WriteLine();
                for(int i = 0; i <= hands.Length - 1; i++)
                {
                    Console.Write("Hand " + i + ": ");
                    if (hands[i] != null)
                    {
                        hands[i].ShowCard();                    
                    } else
                    {
                        Console.WriteLine("Mit einer leeren Hand lässt sich nicht so leicht kämpfen.");
                    }
                }
            } 

            Console.WriteLine("Weitere: ");
            if (hands != null)
            {
                for (int i = 0; i <= hands.Length - 1; i++)
                {
                    int something = 0;
                    if (hands[i] != null)
                    {
                        something++;
                        hands[i].ShowCard();
                    } 
                    if (something == 0)
                    {
                        Console.WriteLine("Mehr hast du Wohl nicht");
                    }
                }
            }
        }
        public void useEquipment(Equipment newEquipment)
        {
          
        } 

    }
}
