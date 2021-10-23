using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
