using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{
    class SnakeMess
    {
        static GameController gameController;

        public static void Main(string[] arguments)
        {
            gameController = new GameController();
            gameController.GameStart();
        }
    }
}