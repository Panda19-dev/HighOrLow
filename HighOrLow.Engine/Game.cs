using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HighOrLow.Engine
{
    public class Game
    {
        LeaderBoard leaderboard = new LeaderBoard(5); //Kommer att visa upp till 5 positions på leaderboard.
        
        public void WelcomeMenu()
        {
            Console.WriteLine("   -----------------------------------");
            Console.WriteLine("   | Welcome to the HighOrLow Game!  |");
            Console.WriteLine("   -----------------------------------");
            Console.WriteLine("   -----------------------------------");
            Console.WriteLine("   |    Thank you for joining us!    |");
            Console.WriteLine("   |    Have a great time playing!   |"); 
            Console.WriteLine("   -----------------------------------");
            Console.WriteLine("         Press enter to continue      ");
            Console.ReadLine();
            while(true)
                MainMenu();
        }

        private void MainMenu()
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("   ----------------------------------------------------");
                Console.WriteLine("   Choose one of the following alternatives to continue\n");
                Console.WriteLine("   1. Start playing the HighOrLow Game!");
                Console.WriteLine("   2. View the current leaderboard.");
                Console.WriteLine("   3. Exit the application.");
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3);

            switch (key)
            {
                case ConsoleKey.D1:
                    StartGame(leaderboard);
                    break;
                case ConsoleKey.D2:
                    ViewLeaderBoard(leaderboard);
                    break;
                case ConsoleKey.D3:
                    Environment.Exit(3);
                    break;
            }

        }

        private void ViewLeaderBoard(LeaderBoard leaderboard)
        {
            Console.WriteLine(leaderboard);
            Console.ReadLine();
        }

        public void StartGame(LeaderBoard leaderBoard)
        {
            Deck cards = new Deck();
            cards.Shuffle();
            var score = 0;

            for (int i = 0; i < 4; i++)
            {
                Card oldCard = cards.GetTopCard();
                Console.Clear();
                Console.WriteLine($"Round {i+1}!");
                for (int j = 0; j < 13; j++)
                {
                    Card newCard = cards.GetTopCard();
                    Console.WriteLine("DEBUG newCard: " + newCard + " j = " + j);
                    ConsoleKey key;
                    do
                    {
                        Console.WriteLine($"Your current card is {oldCard} {Environment.NewLine}" +
                            $" Do you think that the next card is (H)igher or (L)ower?");
                        key = Console.ReadKey(true).Key;

                    } while (key != ConsoleKey.H && key != ConsoleKey.L);

                    if (key == ConsoleKey.H && newCard.IsHigher(oldCard))
                    {
                        Console.WriteLine($"The new card, {newCard}, was higher than {oldCard}.");
                        score++;
                    }
                    else if (key == ConsoleKey.L && newCard.IsLower(oldCard))
                    {
                        Console.WriteLine($"The new card, {newCard}, was lower than {oldCard}");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Wrong guess.");
                        break;
                    }
                    if(j == 12)
                    {
                        score += 50;
                    }
                    oldCard = newCard;
                }
            }
            Console.WriteLine("Game Over!");
            Console.Write("Please enter your username:");
            string name = Console.ReadLine();
            Console.WriteLine($"Your score is {score} points");
            leaderboard.AddPosition(name, score);
            Console.ReadLine();
        }

        public void Loading() // Metod för att skapa en loading screen
        {
            Console.Clear();
            Console.SetCursorPosition(15, 15);
            for (int i = 0; i < 100; i++)
            {
                string l = "*";
                Console.Write(l);
                l += " *";
                Thread.Sleep(500); 
            }
        }

    }
}
