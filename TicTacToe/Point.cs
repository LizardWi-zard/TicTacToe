using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Point
    {
        public Point(int row, int сolumn)
        {
            Row = row;
            Сolumn = сolumn;
        }

        public int Row { get; }
        public int Сolumn { get; }
    }
}
