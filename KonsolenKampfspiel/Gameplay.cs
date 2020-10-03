using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KonsolenKampfspiel
{
    class Gameplay
    {
        Player player;
        List<Card> treasureCards;
        List<Card> doorcards;
        List<Card> handCards;
        Random rnd = new Random();


        public Gameplay(Player player, List<Card> treasureCards, List<Card> doorcards)
        {
            this.player = player;
            this.treasureCards = treasureCards;
            this.doorcards = doorcards;
            this.handCards = new List<Card>();
            TakeTreasureCard(3);
            TakeDoorCard(3);
            ShowHelp();
            CheckingForUserInput();
            PlayerTurn();
        }

        
        private void CheckingForUserInput()
        {
            bool finish = false;
            do
            {
                string keyInput = Console.ReadLine();
                Console.Clear();
                switch (keyInput)
                {
                    case "h":
                        ShowHelp();
                        break;
                    case "k":
                        ShowHandCards();
                        break;
                    case "r":
                        Console.Clear();
                        ShowTreasureCards();
                        player.ShowEquipment();
                        Console.WriteLine("Wenn du eine Karte anwenden möchtest, dann gib einfach den Kartenindex an, anonsten drücke [f]");
                        String input = Console.ReadLine();
                        if (input == "f")
                        {
                            break;
                        }
                        else
                        {
                            Equipment newEquipmentCard = handCards[Convert.ToInt32(input)] as Equipment;
                            if (newEquipmentCard != null)
                            {
                                if (player.UseEquipment(newEquipmentCard))
                                {
                                    DeleteHandCardAt(Convert.ToInt32(input));
                                }
                                player.ShowEquipment();
                            }
                            else
                            {
                                Console.WriteLine("Dies ist leider nicht möglich, bitte vergewissere dich, dass du eine Rüstungskarte ausgewählt hast.");
                            }
                        }
                        break;
                    case "d":
                        //TODO Karten wegwerfen
                        break;
                    case "s":
                        Console.Clear();
                        Console.WriteLine("Deine Stärke: " + player.Strenght);
                        break;
                    case "l":
                        Console.Clear();
                        Console.WriteLine("Dein Level: " + player.Level);
                        break;
                    case "f":
                        finish = true;
                        break;
                    default:
                        ShowHelp();
                        break;
                }
            } while (!finish);
        }

        public static void ShowHelp()
        {
            Console.WriteLine("Um dir deine Handkarten anzusehen drücke einfach \"k\" [k]");
            Console.WriteLine("Eine Rüstungskarte anwenden/ auswechseln [r]");
            Console.WriteLine("Karten kannst du mit [d] wegwerfen");
            Console.WriteLine("Wie stark bin ich? [s]");
            Console.WriteLine("Welches Level habe ich? [l]");
            Console.WriteLine("Wenn du nicht mehr weißt, wie du steuern kannst, lass dir gerne helfen [h]");
            Console.WriteLine("Mit [f] geht das Spiel weiter");
        }
        void PlayerTurn()
        {
            do
            {
                if (handCards.Count > 6)
                {
                    Console.WriteLine("Du hast zu viele Karten auf der Hand.\n Höchstens 6 Karten darfst du auf deiner Hand besitzen");
                }
                else
                {
                    Card doorcard = doorcards[doorcards.Count - 1];
                    doorcards.RemoveAt(doorcards.Count - 1);
                    Monster monster = doorcard as Monster;
                    if (monster != null)
                    {
                        monster.Show(0);
                        Console.WriteLine("Deine Kampfkraft ist: " + player.Strenght);
                        Console.WriteLine("Möchtest du gegen das Monster antreten [1] oder lieber schnell weglaufen [2]?");
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            if (monster.battle(player.Strenght))
                            {
                                Console.WriteLine("Du hast das Monster besiegt!");
                                TakeTreasureCard(monster.treasure);
                                player.IncreaseLevel();
                                ShowHandCards();
                            }
                            else
                            {
                                Console.WriteLine("Du hast leider zu wenig Kampfkraft und muss jetzt dein Glück mit weglaufen versuchen.");
                                RunAway(player.Speed);
                            }
                        }
                        else
                        {
                            RunAway(player.Speed);
                        }

                    }
                    else
                    {
                        handCards.Add(doorcard);
                        Console.Write("Möchtest du gegen ein Monster aus deinen Handkarten kämpfen? [y/n]");
                        if (Console.ReadLine() == "y")
                        {
                            //TODO
                        }
                        else
                        {
                            TakeDoorCard(1);
                        }
                    }
                }
                CheckingForUserInput();
            } while (player.Level < 10);
            Console.Write("Du hast gewonnen!!!!!");
            Console.ReadLine();
            Environment.Exit(0);
        }

        void RunAway(int speed)
        {
            int random = rnd.Next(1, 6);
            if (speed >= random)
            {
                Console.WriteLine("Du hast eine " + random + " gewürfelt.");
                Console.WriteLine("Du bist beim panischen weglaufen über einen Stein gestolpert und das Monster hat dich geschnappt.\nDu bist tot. Das Monster wird nun eine wohlschmeckende Mahlzeit verzehren.");
                GameOver();
            } else
            {
                Console.WriteLine("Du hast eine " + random + " gewürfelt.");
                Console.WriteLine("Du bist erfolgreich weggerannt und hast das Monster abgehängt.");
                return;
            }
        }

        void GameOver()
        {
            Console.WriteLine("Möchtest du es nochmal versuchen? [y/n]");
            if (Console.ReadLine() == "y")
            {
                Preparation.NewGame();
            } else
            {
                Environment.Exit(0);                
            }
        }

        void DeleteHandCardAt(int cardID)
        {
            handCards.RemoveAt(cardID);
        }

        void TakeTreasureCard(int number)
        {
            for (int i = 0; i <= number -1; i++)
            {
                if (treasureCards.Count >=1)
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
                if (treasureCards.Count >= 1)
                {
                    handCards.Add(doorcards[doorcards.Count - 1]);
                    doorcards.RemoveAt(doorcards.Count - 1);
                }
            }
        }

        void ShowTreasureCards()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deine SchatzKarten: \n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i <= handCards.Count - 1; i++)
            {
                if (handCards[i] as Equipment != null)
                {
                    Equipment equipment = handCards[i] as Equipment;
                    equipment.Show(i);
                }
                Console.WriteLine();
            }
        }

        void ShowDoorCards()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deine Türkarten: \n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i <= handCards.Count - 1; i++)
            {
                if (handCards[i] as Monster != null)
                {
                    Monster monster = handCards[i] as Monster;
                    monster.Show(i);
                }
                Console.WriteLine();
            }
        }
        void ShowHandCards()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deine HandKarten: \n");
            ShowDoorCards();
            ShowTreasureCards();
        }
    }
}
