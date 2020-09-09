using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{
    class Gameplay
    {
        public Gameplay(Player player, List<Cards> treasureCards, List<Cards> doorcards)
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
        List<Cards> treasureCards;
        List<Cards> doorcards;
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
                if (handCards[i] != null) {
                    Console.WriteLine(handCards[i].ToString());
                }
                if (handCards[i] != null)
                {
                    Console.WriteLine(handCards[i].ToString());
                }
            }
        }
    }
}
