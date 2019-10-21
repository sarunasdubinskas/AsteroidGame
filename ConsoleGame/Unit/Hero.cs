using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Unit
{
    class Hero : Unit, IPlayerObjects, IMovable, IControlable, IShooting
    {
        public int XPos
        {
            get
            {
                return xPos;
            }
            private set
            {
                xPos = value;
            }
        }
        public int YPos
        {
            get
            {
                return yPos;
            }
            private set
            {
                yPos = value;
            }
        }

        public Hero(string name, int screenWidth, int screenHeight) : base(name, screenWidth, screenHeight)
        {
            xPos = (screenWidth - 1) / 2;
            yPos = screenHeight - 2;
        }

        public void MoveRight()
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(" ");
            xPos++;
            if (checkForScreenBoundariesCollision())
            {
                xPos--;
            }
        }

        public void MoveLeft()
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(" ");
            xPos--;
            if (checkForScreenBoundariesCollision())
            {
                xPos++;
            }
        }
    }
}
