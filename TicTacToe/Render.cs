using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Render
    {
        public Render(Playground pl)
        {
            playground = pl;
        }
        Playground playground;
        public void Clear() => Console.Clear();


        public void RenderPlayground()
        {
            Console.Clear();

            Console.WriteLine($"| {playground[0, 0].State} | {playground[0, 1].State} | {playground[0, 2].State} |");
            Console.WriteLine($"| {playground[1, 0].State} | {playground[1, 1].State} | {playground[1, 2].State} |");
            Console.WriteLine($"| {playground[2, 0].State} | {playground[2, 1].State} | {playground[2, 2].State} |");
        }

        public void RenderEmptySpace(List<char> empty)
        {
            Console.WriteLine();

            Console.WriteLine($"| {empty[0]} | {empty[1]} | {empty[2]} |");
            Console.WriteLine($"| {empty[3]} | {empty[4]} | {empty[5]} |");
            Console.WriteLine($"| {empty[6]} | {empty[7]} | {empty[8]} |");
        }

        public void RenderMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
