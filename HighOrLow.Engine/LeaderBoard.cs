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
        int numberOfPositions;

        List<Position> leaderboard = new List<Position>();
        public LeaderBoard(int numberOfPositions)
        {
            this.numberOfPositions = numberOfPositions;
        }

        public void AddPosition(string userName, int score)
        {
            leaderboard.Add(new Position(userName, score));
        }

        public override string ToString()
        {
            var sortedList = leaderboard.OrderByDescending(c => c.Score).Take(numberOfPositions).ToList(); // Makes me go through a specific length of a sorted list as a leaderboard, which means that ex. the 5 best scores appear.
            string temp = "";
            foreach (Position position in sortedList)
            {
                temp += position.UserName + " : " + position.Score + Environment.NewLine;
            }
            return temp;   
        }
    }
}
