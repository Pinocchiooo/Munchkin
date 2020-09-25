using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{
    class Gameplay
    {
        Player player;
        List<Card> treasureCards;
        List<Card> doorcards;
        List<Card> handCards;

        public Gameplay(Player player, List<Card> treasureCards, List<Card> doorcards)
        {
            this.player = player;
            this.treasureCards = treasureCards;
            this.doorcards = doorcards;
            this.handCards = new List<Card>();
            TakeTreasureCard(3);
            TakeDoorCard(3);
            ShowHandCards();
            checkingForUserInput();
        }

        
        private void checkingForUserInput()
        {
            while (true)
            {
                string keyInput = Console.ReadLine();
                Console.Clear();
                switch (keyInput)
                {
                    case "h":
                        Console.WriteLine("Um dir deine Handkarten anzusehen drücke einfach \"k\" [k]");
                        Console.WriteLine("Eine Rüstungskarte anwenden/ auswechseln [r]");
                        Console.WriteLine("Wenn du nicht mehr weißt, wie steuern kannst, lass dir gerne helfen [h]");
                        break;
                    case "k":
                        ShowHandCards();
                        break;
                    case "e":
                        ShowHandCards();
                        player.showEquipment();
                        Console.WriteLine("Wenn du eine Karte anwenden möchtest, dann gib einfach den Kartenindex an, anonsten drücke [f]");
                        String input = Console.ReadLine();
                        if (input == "f")
                        {
                            break;
                        }
                        else if (input == Convert.ToString(1..handCards.Count))
                        {
                            Equipment newEquipmentCard = handCards[Convert.ToInt32(input) - 1] as Equipment;
                            if (newEquipmentCard != null)
                            {
                                player.useEquipment(newEquipmentCard);
                                player.showEquipment();
                            }
                            else
                            {
                                Console.WriteLine("Dies ist leider nicht möglich, bitte vergewissere dich, dass du eine Rüstungskarte ausgewählt hast.");
                            }
                        }
                        break;
                }
            }
        }

        void Playerturn()
        {
        }
        
        void TakeTreasureCard(int number)
        {
            for (int i = 0; i <= number -1; i++)
            {
                if (handCards.Count < 6 && treasureCards.Count >=1)
                {
                    handCards.Add(treasureCards[treasureCards.Count - 1]);
                    treasureCards.RemoveAt(treasureCards.Count - 1);
                }
            }
        }
        void TakeDoorCard(int number)
        {
            for (int i = 0; i <= number -1; i++)
            {
                if (handCards.Count < 6 && treasureCards.Count >= 1)
                {
                    handCards.Add(doorcards[doorcards.Count - 1]);
                    doorcards.RemoveAt(doorcards.Count - 1);
                }
            }
        }

        void ShowHandCards()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deine HandKarten: \n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i <= handCards.Count - 1; i++)
            {
                if (handCards[i] as Monster != null) {
                    Monster monster = handCards[i] as Monster;
                    monster.Show();
                } else if (handCards[i] as Equipment != null)
                {
                    Equipment equipment = handCards[i] as Equipment;
                    equipment.Show();
                }
                Console.WriteLine();
            }
        }
    }
}
