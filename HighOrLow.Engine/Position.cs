using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighOrLow.Engine
{
    public class Position
    {
        public string UserName { get; }
        public int Score { get; }

        public Position(string username, int score)
        {
            this.UserName = username;
            this.Score = score;
        }
    }
}
