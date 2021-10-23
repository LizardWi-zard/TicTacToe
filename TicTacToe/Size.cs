using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
    }
}
