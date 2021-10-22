using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Size size = new Size(3,3);

            Playground playground = new Playground(size);

            Render render = new Render();

            Game game = new Game(render);

            game.StartGame();


            //render.ClearPoints(playground);
            //render.RenderPlayground(playground);
        }
    }

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

        //public Cell this[Point point] { get; }
    }

    class Render
    {

        public void Clear() => Console.Clear();

        
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
        public Game(Render render)
        {
            this.render = render;
        }
        Render render;
        public Point point = new Point();

        public bool playingGame = false;
        public bool hasWinner = false;
        public int gameMoves = 0;
        public char side = ' ';

        public void StartGame()
        {
            playingGame = true;
            side = SideDesider();
            render.RenderMessage($"Your side is \"{side}\"");
        }

        public void GameMove()
        {
            while(playingGame == true && gameMoves < 9)
            {
                AcceptMove();
                CreateMove();
            }
        }


        public void CreateMove()
        {

        }

        public char SideDesider()
        {
            render.RenderMessage("Choose side");
            render.RenderMessage("1 => X \t 2 => O");
            render.RenderMessage("auto choose => X");
            char holder = (char)Console.ReadKey().Key;

            render.Clear();
            
            if (holder == '1' || holder != '2')
                return 'X';
            else 
                return 'O';
        }

        public void CheckForWin()
        {

        }

        public void ClearPoints(Playground pl)
        {
            for (int w = 0; w < pl.Size.Width; w++)
            {
                for (int h = 0; h < pl.Size.Height; h++)
                {
                    pl.PointPosition[w, h] = '_';
                }
            }
        }
        public void AcceptMove()
        {
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    
                    break;



                case '\0':
                    break;
            }
        }
    }
}
