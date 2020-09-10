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
            takeTreasureCard(3);
            takeDoorCard(3);
            showHandCards();
            Console.ReadLine();
        }
        
        void takeTreasureCard(int number)
        {
            for (int i = 0; i <= number; i++)
            {
                if (handCards.Count < 6 && treasureCards.Count >=1)
                {
                    handCards.Add(treasureCards[treasureCards.Count - 1]);
                    treasureCards.RemoveAt(treasureCards.Count - 1);
                }
            }
        }
        void takeDoorCard(int number)
        {
            for (int i = 0; i <= number; i++)
            {
                if (handCards.Count < 6 && treasureCards.Count >= 1)
                {
                    handCards.Add(doorcards[doorcards.Count - 1]);
                    doorcards.RemoveAt(doorcards.Count - 1);
                }
            }
        }

        void showHandCards()
        {
            for (int i = 0; i <= handCards.Count - 1; i++)
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
