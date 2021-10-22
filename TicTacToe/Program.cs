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
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }

    class Playground
    {
        public Playground(Size size) 
        { 
            Size = size;
            PointPosition = new Cell[size.Width , size.Height];
        }
       
        Cell[ , ] PointPosition { get; }

        public Cell this[Point point] 
        { 
            get 
            {
                return PointPosition[point.X, point.Y];
            } 
        }

        public Cell this[int x, int y]
        {
            get
            {
                return PointPosition[x, y];
            }
        }

        public Size Size { get; }
    }

    class Cell
    {
        public char State { get; set; } //TODO: исправисть с Char на нормальный тип
    }

    class Render
    {

        public void Clear() => Console.Clear();

        
        public void RenderPlayground(Playground pl)
        {
            Console.Clear();

            Console.WriteLine($"|{pl[0, 0]}|{pl[0, 1]}|{pl[0, 2]}|");
            Console.WriteLine($"|{pl[1, 0]}|{pl[1, 1]}|{pl[1, 2]}|");
            Console.WriteLine($"|{pl[2, 0]}|{pl[2, 1]}|{pl[2, 2]}|");
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
        //public Point point = new Point();

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
                    pl[w, h].State = '_';
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
