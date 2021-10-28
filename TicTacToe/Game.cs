using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    public enum StateEnum
    {
        _ = 1,
        X,
        O
    }

    class Game
    {
        Render render;
        Playground playground;

        public Game(Render render, Playground pl)
        {
            this.render = render;
            playground = pl;
        }


        List<char> emptySpase = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        Dictionary<int, Point> coordinatsMap = new Dictionary<int, Point>()
        {
            {1, new Point(0, 0) }, {2, new Point(0, 1) }, {3, new Point(0, 2) },
            {4, new Point(1, 0) }, {5, new Point(1, 1) }, {6, new Point(1, 2) },
            {7, new Point(2, 0) }, {8, new Point(2, 1) }, {9, new Point(2, 2) }
        };

        bool playingGame = false;
        bool botTurn = false;
        int gameMoves = 0;

        StateEnum playerSide = StateEnum._;
        StateEnum botSide = StateEnum.O;

        public void StartGame()
        {
            playingGame = true;
            playerSide = SideDesider();
            ClearPoints();
            render.RenderMessage($"Your side is \"{playerSide}\"");
            GameMove();
        }

        void GameMove()
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

        StateEnum SideDesider()
        {
            render.RenderMessage("Choose side");
            render.RenderMessage("1 => X \t 2 => O");
            render.RenderMessage("auto choose => X");
            char holder = (char)Console.ReadKey().Key;

            render.Clear();

            if (holder == '1' || holder != '2')
                return StateEnum.X;

            botSide = StateEnum.X;
            botTurn = true;
            return StateEnum.O;
        }

        void ClearPoints()
        {
            for (int w = 0; w < playground.Size.Width; w++)
            {
                for (int h = 0; h < playground.Size.Height; h++)
                    playground[w, h] = new Cell { State = StateEnum._ };
                
            }
        }

        void CreateMove()
        {
            render.Clear();
            bool turnNotFound = true;
            var random = new Random();

            while (turnNotFound)
            {
                string pos = random.Next(1, 9).ToString();

                int row = coordinatsMap[int.Parse(pos)].Row;
                int column = coordinatsMap[int.Parse(pos)].Сolumn;

                if (playground[row, column].State == StateEnum._)
                {
                    playground[row, column].State = botSide;
                    turnNotFound = false;
                    emptySpase[int.Parse(pos) - 1] = '-';
                }
            }
            render.RenderPlayground();
        }

        void AcceptMove()
        {
            render.RenderEmptySpace(emptySpase);
            bool avalibleMove = false;
            string holder = "";

            while (!avalibleMove)
            {
                holder = Console.ReadKey().KeyChar.ToString();
                avalibleMove = IsAvalibleMove(holder[0]);
            }

            emptySpase[int.Parse(holder) - 1] = '-';

            int row = coordinatsMap[int.Parse(holder)].Row;
            int column = coordinatsMap[int.Parse(holder)].Сolumn;

            playground[row, column].State = playerSide;
            render.Clear();
            render.RenderPlayground();
        }

        bool IsAvalibleMove(char input)
        {
            foreach (var item in emptySpase)
            {
                if (input == item)
                    return true;

            }

            render.Clear();
            render.RenderPlayground();
            render.RenderMessage("Invalid input");
            render.RenderEmptySpace(emptySpase);
            return false;
        }

        void CheckForWin(StateEnum side)
        {
            if (
                (playground[0, 0].State == side) && (playground[1, 0].State == side) && (playground[2, 0].State == side) ||
                (playground[0, 1].State == side) && (playground[1, 1].State == side) && (playground[2, 1].State == side) ||
                (playground[0, 2].State == side) && (playground[1, 2].State == side) && (playground[2, 2].State == side) ||
                (playground[0, 0].State == side) && (playground[0, 1].State == side) && (playground[0, 2].State == side) ||
                (playground[1, 0].State == side) && (playground[1, 1].State == side) && (playground[1, 2].State == side) ||
                (playground[2, 0].State == side) && (playground[2, 1].State == side) && (playground[2, 2].State == side) ||
                (playground[0, 0].State == side) && (playground[1, 1].State == side) && (playground[2, 2].State == side) ||
                (playground[0, 2].State == side) && (playground[1, 1].State == side) && (playground[2, 0].State == side)) 
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
