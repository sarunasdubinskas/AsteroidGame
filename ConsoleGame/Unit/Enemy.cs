using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Unit
{
    class Enemy : Unit, IEnemyObjects, IMovable
    {
        private Random rnd = new Random();
        private readonly int id;
        private int speed;
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

        public Enemy(string name, int id, int screenWidth, int screenHeight, int playAreaYPadding) : base(name, screenWidth, screenHeight)
        {
            xPos = rnd.Next(2, screenWidth - 1);
            speed = rnd.Next(1, 4);
            yPos = playAreaYPadding + 1;
            this.id = id;
        }

        public void MoveDown()
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(" ");
            yPos += speed;
        }

        public int GetID()
        {
            return id;
        }



    }
}
