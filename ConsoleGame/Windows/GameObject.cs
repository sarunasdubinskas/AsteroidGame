using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Windows
{
    abstract class GameObject
    {
        private int x;
        private int y;
        private int width;
        private int height;

        public GameObject(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public int X
        { get { return x; } }
        public int Y { get { return y; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }

        abstract public void Render();
    }
}
