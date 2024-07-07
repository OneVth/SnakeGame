using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    internal class Player
    {
        public int PosX;
        public int PosY;
        public List<(int x, int y)> Body = new List<(int x, int y)>();
        bool isDead = false;
        Direction currentDirection;

        public bool IsDead { get { return isDead; } }

        public Player(Layout gameLayout)
        {
            currentDirection = Direction.Right;

            PosX = gameLayout.Width / 2;
            PosY = gameLayout.Height / 2;

            Body.Add((x: PosX, y: PosY));

            Layout.GameBoard[PosY][PosX] = "■";
        }
        public void EatItem()
        {
            Body.Add(Body[Body.Count - 1]);
        }

        public void ChangeDirection(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    if(currentDirection != Direction.Down)
                        currentDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    if (currentDirection != Direction.Up)
                        currentDirection = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentDirection != Direction.Right)
                        currentDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    if (currentDirection != Direction.Left)
                        currentDirection = Direction.Right;
                    break;
                default:
                    break;
            }
        }
        public void Move(Layout  layout)
        {
            int nextPosY = PosY;
            int nextPosX = PosX;

            

            switch (currentDirection)
            {
                case Direction.Up:
                    nextPosY -= 1;
                    break;
                case Direction.Down:
                    nextPosY += 1;
                    break;
                case Direction.Left:
                    nextPosX -= 1;
                    break;
                case Direction.Right:
                    nextPosX += 1;
                    break;
                default:
                    break;
            }

            if (nextPosX < 0 || nextPosY < 0 ||
                       nextPosX >= layout.Width || nextPosY >= layout.Height)
            {
                GameOver();
            }

            Body.Insert(0, (nextPosX, nextPosY));
            Body.RemoveAt(Body.Count - 1);

            PosX = nextPosX;
            PosY = nextPosY;
        }

        public bool IsAtPosition(int x, int y)
        {
            foreach ((int x, int y) segment in Body)
            {
                if (segment.x == x && segment.y == y) 
                    return true;
            }
            return false;
        }

        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            isDead = true;
            return;
        }
    }
}
