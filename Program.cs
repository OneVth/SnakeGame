using System;
using System.Threading;

namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Layout gameLayout = new Layout(25, 15);

            Player player = new Player(gameLayout);

            Item item = new Item();

            item.Spawn(gameLayout);

            while (!player.IsDead)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey input = Console.ReadKey(true).Key;
                    player.ChangeDirection(input);
                }

                player.Move(gameLayout);
                Console.Clear();
                gameLayout.Render(player, item);
                Thread.Sleep(200);
            }
        }
    }
}
