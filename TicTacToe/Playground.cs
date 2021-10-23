using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Playground
    {
        public Playground(Size size)
        {
            Size = size;
            PointPosition = new Cell[size.Width, size.Height];
        }

        Cell[,] PointPosition { get; }

        public Size Size { get; }

        public Cell this[Point point]
        {
            get => PointPosition[point.X, point.Y];
            set
            {
                PointPosition[point.X, point.Y] = value;
            }
        }

        public Cell this[int x, int y]
        {
            set
            {
                PointPosition[x, y] = value;
            }
            get => PointPosition[x, y];
        }

    }
}
