using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KonsolenKampfspiel
{
    class Gameplay
    {
        #region Variablen
        Player player;
        List<Card> treasureCards;
        List<Card> doorcards;
        List<Card> handCards;
        Random rnd = new Random();
        #endregion

        #region Konstruktor
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
        #endregion

        #region Methode - public
        public static void ShowHelp()
        {
            Console.WriteLine("Um dir deine Handkarten anzusehen drücke einfach \"k\" [k]");
            Console.WriteLine("Eine Equipmentkarte anzuwenden/ auszuwechseln [e]");
            Console.WriteLine("Karten verkaufen (pro 1000 Goldstücke erhälst du eine Stufe.) [v]");
            Console.WriteLine("Wie stark bin ich? [s]");
            Console.WriteLine("Welches Level habe ich? [l]");
            Console.WriteLine("Wenn du nicht mehr weißt, wie du steuern kannst, lass dir gerne helfen [h]");
            Console.WriteLine("Mit [f] geht das Spiel weiter");
        }
        #endregion

        #region Methoden - private
        //Diese Methode lässt den User zwischen in ShowHelp() beschriebenen Interaktionen wählen, sie wird solange ausgeführt, bis das Programm endet.
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
                    case "e":
                        editEquipment();
                        break;
                    case "v":
                        sellEquipment();
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
                Console.Write("\n\nWas Möchtest du tun?  ");
            } while (!finish);
        }
        private void sellEquipment()
        {
            ShowTreasureCards();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Gebe den Index aller Karten, die du verkaufen möchtest, kommagetrennt an. z.B. [1,5,4]");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                int[] indexInput = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

                int jewels = 0;
                var indexe = indexInput.OrderByDescending(s => s);
                //TODO: Check if each number is maximum user one time
                foreach (int index in indexe)
                {
                    Equipment card = handCards[index] as Equipment;
                    jewels += card.jewel;
                    handCards.RemoveAt(index);
                }
                int increase = Convert.ToInt32(jewels / 1000);
                player.IncreaseLevel(increase);
                Console.Clear();
                Console.WriteLine("Dein Equipment liegt nun auf dem Marktplatz. Die dafür erhaltenen Goldstücke: " + jewels + " hast du gegen " + increase + " Stufe(n) eingetauscht.");
            }
            catch
            {
                Console.WriteLine("Die angegebenen Indexe waren nicht alle als Equipment zu erkennen.");
                ShowHelp();
            }
        }
        private void editEquipment()
        {
            Console.Clear();
            ShowTreasureCards();
            player.ShowEquipment();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Wenn du eine Karte anwenden möchtest, dann gib einfach den Kartenindex an, anonsten drücke [f]");
            Console.ForegroundColor = ConsoleColor.White;
            String input = Console.ReadLine();
            if (input != "f")
            {
                try
                {
                    Equipment newEquipmentCard = handCards[Convert.ToInt32(input)] as Equipment;
                    if (newEquipmentCard != null)
                    {
                        if (player.UseEquipment(newEquipmentCard))
                        {
                            DeleteHandCardAt(Convert.ToInt32(input));
                        }
                        Console.Clear();
                        player.ShowEquipment();
                    }
                    else
                    {
                        Console.WriteLine("Dies ist leider nicht möglich, bitte vergewissere dich, dass du eine Rüstungskarte ausgewählt hast.");
                    }
                }
                catch
                {
                    Console.Clear();
                    ShowHelp();
                }
            }
        }

        //Hier findet die Ziehung einer Türkarte statt, die im Falle eines Monsters einen Kampf einleiten, der mit Sieg, oder einem Weglaufversuch endet.
        private void PlayerTurn()
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
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ein Monster greift dich an.");
                        monster.Show(0);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Deine Kampfkraft ist: " + player.Strenght);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Möchtest du gegen das Monster antreten [1] oder lieber schnell weglaufen [2]?");
                        Console.ForegroundColor = ConsoleColor.White;
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            if (monster.battle(player.Strenght))
                            {
                                Console.WriteLine("Du hast das Monster besiegt!");
                                TakeTreasureCard(monster.treasure);
                                player.IncreaseLevel(monster.increasment);
                                ShowHandCards();
                                Console.WriteLine("Bitte eine Taste drücken.");
                                Console.ReadKey();
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
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Möchtest du gegen ein Monster aus deinen Handkarten kämpfen? [j/n]");
                        Console.ForegroundColor = ConsoleColor.White;

                        if (Console.ReadLine() == "j")
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
            Console.Clear();
            Console.Write("Du hast gewonnen!!!!!");
            Console.ReadLine();
            Environment.Exit(0);
        }

        private void RunAway(int speed)
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

        private void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Möchtest du es nochmal versuchen? [j/n]");
            Console.ForegroundColor = ConsoleColor.White;

            if (Console.ReadLine() == "j")
            {
                Console.Clear();
                Preparation.NewGame();
            } else
            {
                Environment.Exit(0);                
            }
        }

        #region Kartenmanagement

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
            for (int i = 0; i <= handCards.Count - 1; i++)
            {
                if (handCards[i] as Equipment != null)
                {
                    Equipment equipment = handCards[i] as Equipment;
                    equipment.Show(i);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        void ShowDoorCards()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deine Türkarten: \n");
            for (int i = 0; i <= handCards.Count - 1; i++)
            {
                if (handCards[i] as Monster != null)
                {
                    Monster monster = handCards[i] as Monster;
                    monster.Show(i);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        void ShowHandCards()
        {
            ShowDoorCards();
            ShowTreasureCards();
        }
        #endregion

        #endregion
    }
}
