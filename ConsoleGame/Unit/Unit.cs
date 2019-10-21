using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Unit
{
    class Unit
    {
        protected int xPos;
        protected int yPos;
        protected string name;
        private int screenWidth;
        private int screenHeight;

        public Unit(string name, int screenWidth, int screenHeight)
        {
            this.name = name;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public void PrintInfo()
        {
            Console.WriteLine(xPos + " " + yPos);
        }

        public bool checkForScreenBoundariesCollision()
        {
            return (xPos < 1 || xPos > screenWidth);
        }

        public string GetName()
        {
            return name;
        }
    }
}
