using HighOrLow.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighOrLow
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(); //Creates a new instance of the Game class
            game.WelcomeMenu(); //Initializing the game by calling the method WelcomeMenu()

        }
    }
}
