using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HighOrLow.Engine.Tests
{
    [TestClass]
    public class LeaderBoardTests
    {
        [TestMethod]
        public void CanCreateInstanceOFHighScore()
        {
            LeaderBoard leaderboard = new LeaderBoard(3);
            
        }

        [TestMethod]
        public void CanAddPositionToLeaderBoard()
        {
            LeaderBoard leaderboard = new LeaderBoard(2);
            leaderboard.AddPosition("o", 0);
            leaderboard.AddPosition("j", 3);
        }

        [TestMethod]
        public void CorrectToStringMethod()
        {
            LeaderBoard leaderboard = new LeaderBoard(2);
            leaderboard.AddPosition("o", 0);
            leaderboard.AddPosition("j", 3);
            var temp = leaderboard.ToString();
            Assert.AreEqual("o" + " : " + "0" + Environment.NewLine + "j" + " : " + "3" + Environment.NewLine, temp);
        }
    }
}
