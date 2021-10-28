using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Size size = new Size(3, 3);

            Playground playground = new Playground(size);

            Render render = new Render(playground);

            Game game = new Game(render, playground);

            game.StartGame();

            Console.ReadKey();
        }
    }
}
