using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{
    class Gameplay
    {
        public Gameplay(Player player, List<TreasureCards> treasureCards, List<DoorCards> doorcards)
        {
            this.player = player;
            this.treasureCards = treasureCards;
            this.doorcards = doorcards;
            this.handCards = new List<Cards>();
            takeTreasureCard(3);
            takeDoorCard(3);
            showHandCards();
            Console.ReadLine();
        }

        Player player;
        List<TreasureCards> treasureCards;
        List<DoorCards> doorcards;
        List<Cards> handCards;
        
        void takeTreasureCard(int number)
        {
            for (int i = 1; i <= 6; i++)
            {
                if (handCards.Count < 6)
                {
                    handCards.Add(treasureCards[treasureCards.Count - 1]);
                    treasureCards.RemoveAt(treasureCards.Count - 1);
                }
            }
        }
        void takeDoorCard(int number)
        {
            for (int i = 1; i <= 6; i++)
            {
                if (handCards.Count < 6)
                {
                    handCards.Add(doorcards[doorcards.Count - 1]);
                    doorcards.RemoveAt(doorcards.Count - 1);
                }
            }
        }

        void showHandCards()
        {
            for (int i = 1; i <= handCards.Count; i++)
            {
                if (handCards[i].DoorCards != null) {
                    Console.WriteLine(handCards[i].DoorCards.ToString());
                }
                if (handCards[i].TreasureCards != null)
                {
                    Console.WriteLine(handCards[i].TreasureCards.ToString());
                }
            }
        }
    }
}
