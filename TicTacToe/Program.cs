using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Size size = new Size(3,3);

            Playground playground = new Playground(size);

            Render gameBoard = new Render();

            gameBoard.ClearPoints(playground);
            gameBoard.RenderPlayground(playground);
        }
    }

    public class Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { set; get; }
        public int Height { set; get; }
    }

    class Point
    {
        public int X { get; }
        public int Y { get; }
    }

    class Playground
    {
        public Playground(Size size) { Size = size; PointPosition = new char[size.Width, size.Height]; }
       
        public char[ , ] PointPosition { get; }

        public Size Size { get; }

        //public Cell this[Point point] => { ;}
    }

    class Render
    {

        public void ClearPoints(Playground pl)
        {
            for(int w = 0; w < pl.Size.Width; w++)
            {
                for (int h = 0; h < pl.Size.Height; h++)
                {
                    pl.PointPosition[w, h] = '_'; 
                }
            }
        }

        
        public void RenderPlayground(Playground pl)
        {
            Console.Clear();

            Console.WriteLine($"|{pl.PointPosition[0, 0]}|{pl.PointPosition[0, 1]}|{pl.PointPosition[0, 2]}|");
            Console.WriteLine($"|{pl.PointPosition[1, 0]}|{pl.PointPosition[1, 1]}|{pl.PointPosition[1, 2]}|");
            Console.WriteLine($"|{pl.PointPosition[2, 0]}|{pl.PointPosition[2, 1]}|{pl.PointPosition[2, 2]}|");
        }

        public void RenderMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Game
    {
        
    }
}
