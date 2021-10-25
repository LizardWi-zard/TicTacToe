using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    class Game
    {
        public Game(Render render, Playground pl)
        {
            this.render = render;
            this.pl = pl;
        }
        Render render;
        Playground pl;
        //public Point point = new Point();

        List<char> emptySpase = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9'};

        public bool playingGame = false;
        public bool hasWinner = false;
        public bool botTurn = false;
        public int gameMoves = 0;
        public char playerSide = ' ';
        public char botSide = 'O';

        public void StartGame()
        {
            playingGame = true;
            playerSide = SideDesider();
            ClearPoints();
            render.RenderMessage($"Your side is \"{playerSide}\"");
            GameMove();
        }

        public void GameMove()
        {
            Thread.Sleep(1000);
            render.RenderPlayground();
            while (playingGame == true && gameMoves <= 8)
            {
                if (botTurn)
                {
                    CreateMove();
                    CheckForWin(botSide);
                }
                else
                {
                    AcceptMove();
                    CheckForWin(playerSide);
                    
                }

                botTurn = !botTurn;
                gameMoves++;
                
                Thread.Sleep(500);
            }
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
            {
                botSide = 'X';
                botTurn = true;
                return 'O';
            }
        }

        public void ClearPoints()
        {
            for (int w = 0; w < pl.Size.Width; w++)
            {
                for (int h = 0; h < pl.Size.Height; h++)
                {
                    pl[w, h] = new Cell{ State = '_' };
                }
            }
        }

        public void CreateMove()
        {
            render.Clear();
            bool turnNotFound = true;
            var random = new Random();

            while (turnNotFound)
            {
                string pos = random.Next(1, 9).ToString();
                
                int x = GetPosition(pos[0]).Item1;
                int y = GetPosition(pos[0]).Item2;

                if (pl[x, y].State == '_')
                {
                    pl[x, y].State = botSide;
                    turnNotFound = false;
                    emptySpase[int.Parse(pos)-1] = '-'; 
                    //TODO: Сделать список доступный ходов
                }
            }
            render.RenderPlayground();
        }

        public void AcceptMove()
        {
            render.RenderEmptySpace(emptySpase);
            bool avalibleMove = false;
            string holder = "";

            while(!avalibleMove)
            {
                holder = Console.ReadKey().KeyChar.ToString();
                avalibleMove = IsAvalibleMove(holder[0]);
            }

            emptySpase[int.Parse(holder) - 1] = '-';
            int x = GetPosition(holder[0]).Item1;
            int y = GetPosition(holder[0]).Item2;

            pl[x, y].State = playerSide;
            render.Clear();
            render.RenderPlayground();
        }

        public bool IsAvalibleMove(char input) 
        {
            foreach(var item in emptySpase)
            {
                if(input == item)
                {
                    return true;
                }
            }
            render.Clear();
            render.RenderPlayground();
            render.RenderMessage("Invalid input");
            render.RenderEmptySpace(emptySpase);
            return false;
        }

        public Tuple<int, int> GetPosition(char a)
        {
            switch (a)
            {
                case '1':
                    return Tuple.Create(0, 0);
                case '2':
                    return Tuple.Create(0, 1);
                case '3':
                    return Tuple.Create(0, 2);
                case '4':
                    return Tuple.Create(1, 0);
                case '5':
                    return Tuple.Create(1, 1);
                case '6':
                    return Tuple.Create(1, 2);
                case '7':
                    return Tuple.Create(2, 0);
                case '8':
                    return Tuple.Create(2, 1);
                case '9':
                    return Tuple.Create(2, 2);

                default:
                    return Tuple.Create(0, 0);
            }
        }

        public void CheckForWin(char side)
        {
            if (
                (pl[0, 0].State == side) && (pl[1, 0].State == side) && (pl[2, 0].State == side) ||
                (pl[0, 1].State == side) && (pl[1, 1].State == side) && (pl[2, 1].State == side) ||
                (pl[0, 2].State == side) && (pl[1, 2].State == side) && (pl[2, 2].State == side) ||
                (pl[0, 0].State == side) && (pl[0, 1].State == side) && (pl[0, 2].State == side) ||
                (pl[1, 0].State == side) && (pl[1, 1].State == side) && (pl[1, 2].State == side) ||
                (pl[2, 0].State == side) && (pl[2, 1].State == side) && (pl[2, 2].State == side) ||
                (pl[0, 0].State == side) && (pl[1, 1].State == side) && (pl[2, 2].State == side) ||
                (pl[0, 2].State == side) && (pl[1, 1].State == side) && (pl[2, 0].State == side)) 
            {
                render.RenderMessage($"The winner is {side}!");
                playingGame = false;
            } 
            else if (gameMoves >= 8)
            {
                render.RenderMessage("Draw!");
                playingGame = false;
            }
        }
    }
}
