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
        LeaderBoard leaderboard = new LeaderBoard(7); //Will show up to 5 positions on the leaderboard.

        public void WelcomeMenu() //Method that will be called in the beginning of my game to introduce the player to it.
        {
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("   -----------------------------------");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("   | Welcome to the HighOrLow Game!  |");
            Console.SetCursorPosition(40, 14);
            Console.WriteLine("   -----------------------------------");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("   -----------------------------------");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("   |    Thank you for joining us!    |");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("   |    Have a great time playing!   |");
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("   -----------------------------------");
            Console.SetCursorPosition(40, 19);
            Console.WriteLine("         Press enter to continue      ");
            Console.SetCursorPosition(40, 20);
            Console.ReadLine();
            while(true) //Using while(true) so that everytime you have played either the view leaderboard or finished the game you can press enter and come back to main menu.
                MainMenu();
        }

        private void MainMenu() //A method that contains the main menu for the game aswell as a switch statement looking for a key press.
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

            switch (key) //
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

        private void ViewLeaderBoard(LeaderBoard leaderboard) //Method that will write out a leaderboard because I overrided the .ToString method.
        {
            Console.WriteLine(leaderboard);
            Console.ReadLine();
        }

        public void StartGame(LeaderBoard leaderBoard) //Method which is initializing the game
        {
            Deck cards = new Deck(); //Instance of deck
            cards.Shuffle(); //Shuffles the instance
            var score = 0;
            Loading(); //Calling a loading screen 
            for (int i = 0; i < 4; i++) //Loop that determines which round the player is on.
            {
                Card oldCard = cards.GetTopCard();
                Console.Clear();
                Console.WriteLine("---------------");
                Console.WriteLine($"Round {i+1}!");
                Console.WriteLine("---------------");
                for (int j = 0; j < 12; j++) //Loop that determines which turn the player is on.
                {
                    Card newCard = cards.GetTopCard();
                    //Console.WriteLine("DEBUG newCard: " + newCard + " j = " + j); //Cheat so that I could test my program.
                    ConsoleKey key;
                    do
                    {
                        
                        Console.WriteLine($"Your current card is {oldCard} {Environment.NewLine}" +
                            $" Do you think that the next card is (H)igher or (L)ower?" + Environment.NewLine);
                        key = Console.ReadKey(true).Key; //Looking for a pressed key
                        if (key != ConsoleKey.H && key != ConsoleKey.L)
                        {
                            Console.WriteLine("You must press either the key H or L to move on!");
                        }

                    } while (key != ConsoleKey.H && key != ConsoleKey.L); //Will not exit the do while loop until the key pressed is either h or l

                    if (key == ConsoleKey.H && newCard.IsHigher(oldCard)) //Checks if the H key is pressed and if the newcard is higher than the old cards and if so then prints the results.
                    {
                        Console.WriteLine($"The new card, {newCard}, was higher than {oldCard}.");
                        Console.WriteLine($"Score : {score}");
                        score++;
                    }
                    else if (key == ConsoleKey.L && newCard.IsLower(oldCard)) //Checks if the L key is pressed and if the newcard is lower than the old cards and if so then prints the results.
                    {
                        Console.WriteLine($"The new card, {newCard}, was lower than {oldCard}");
                        Console.WriteLine($"Score : {score}");
                        score++;
                    }
                    else //Otherwise print that the guess was wrong and break the inner for loop so you move on to the next round.
                    {
                        Console.WriteLine("Wrong guess.");
                        Console.WriteLine("");
                        break;
                    }
                    if(j == 11)
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

        public void Loading() // Method that creates a simple loading screen by just setting the thread.sleep() to 150.
        {
            Console.Clear();
            Console.SetCursorPosition(45, 14);
            Console.WriteLine("Loading game");
            Console.SetCursorPosition(42, 15);
            for (int i = 0; i < 8; i++)
            {
                string l = " *";
                Console.Write(l);
                l += " *";
                Thread.Sleep(150); 
            }
            Console.Clear();
            Console.SetCursorPosition(45, 14);
            Console.WriteLine("GAME IS READY TO START!");
            Console.SetCursorPosition(45, 15);
            Console.WriteLine("Press Enter To Continue!");
            Console.ReadLine();
        }

    }
}
