using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HighOrLow.Engine
{
    public class LeaderBoard
    {
        int numberOfPositions; // A variable that determine how many positions that will be shown on the leaderboard.

        List<Position> leaderboard = new List<Position>();
        public LeaderBoard(int numberOfPositions)
        {
            this.numberOfPositions = numberOfPositions;
        }

        public void AddPosition(string userName, int score) //Adds a position or a player to the leaderboard.
        {
            leaderboard.Add(new Position(userName, score));
        }

        public override string ToString() //Method that will be called if you try to ex. Console.WriteLine(leaderboard)
        {
            Console.Clear();
            if (leaderboard.Count == 0) //When the leaderboard is empty
            {
                string temp = "";
                temp += "-----------------------------------------" + Environment.NewLine;
                temp += "      The LeaderBoard Is Empty!" + Environment.NewLine;
                temp += "-----------------------------------------" + Environment.NewLine;
                return temp;
            }
            else //Prints a sorted leaderboard.
            {
                var sortedList = leaderboard.OrderByDescending(c => c.Score).Take(numberOfPositions).ToList(); // Makes me go through a specific length of a sorted list as a leaderboard, which means that ex. the 5 best scores appear.
                string temp = "";
                temp += "         LEADERBOARD" + Environment.NewLine;
                temp += "-----------------------------------------" + Environment.NewLine;
                foreach (Position position in sortedList)
                {
                    temp += position.UserName + " : " + position.Score + Environment.NewLine;
                }
                temp += "-----------------------------------------" + Environment.NewLine;
            return temp;   
            }
        }
    }
}
