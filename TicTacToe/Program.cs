using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Size
    {
        public int Width { get; }
        public int Height { get; }
    }

    class Point
    {
        public int X { get; }
        public int Y { get; }
    }

    class Playground
    {
        public char[,] PointPosition { get; }

        public Playground(Size size) { }

        public Size Size { get; }

        //public Cell this[Point point] => { ;}
    }

    class Render
    {
        public void Clear() => Console.Clear();
        
        public void RenderPlayground(Playground playground)
        {
            Clear();
            Console.WriteLine($"|{playground.PointPosition[0, 0]}|{playground.PointPosition[0, 1]}|{playground.PointPosition[0, 2]}|");
            Console.WriteLine($"|{playground.PointPosition[1, 0]}|{playground.PointPosition[1, 1]}|{playground.PointPosition[1, 2]}|");
            Console.WriteLine($"|{playground.PointPosition[2, 0]}|{playground.PointPosition[2, 1]}|{playground.PointPosition[2, 2]}|");
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
