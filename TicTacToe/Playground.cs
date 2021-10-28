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
            get => PointPosition[point.Row, point.Сolumn];
            set
            {
                PointPosition[point.Row, point.Сolumn] = value;
            }
        }

        public Cell this[int row, int сolumn]
        {
            get => PointPosition[row, сolumn];
            set
            {
                PointPosition[row, сolumn] = value;
            }
        }

    }
}
