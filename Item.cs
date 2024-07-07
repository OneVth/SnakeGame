using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    internal class Item
    {
        int posX;
        int posY;
        bool isSpawned = false;
        
        public int PosX { get { return posX; } }
        public int PosY { get { return posY; } }

        Random rand;

        public void Spawn(Layout layout)
        {
            rand = new Random();

            posX = rand.Next(layout.Width);
            posY = rand.Next(layout.Height);
            ChangeState();
        }

        public bool IsSpawned()
        {
            return isSpawned;
        }

        public void ChangeState()
        {
            isSpawned = !isSpawned;
        }
    }
}
