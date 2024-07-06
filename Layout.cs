using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    internal class Layout
    {
        int width;
        int height;
        public static List<List<string>> GameBoard;

        public int Width { get { return width; } private set { width = value; } }
        public int Height { get { return height; } private set { height = value; } }

        public Layout(int width, int height)
        {
            this.width = width;
            this.height = height;

            GameBoard = new List<List<string>>();

            for (int i = 0; i < height; i++)
            {
                GameBoard.Add(new List<string>());
                for (int j = 0; j < width; j++)
                {
                    GameBoard[i].Add("□");
                }
            }
        }

        public void Render(Player player)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(GameBoard[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
