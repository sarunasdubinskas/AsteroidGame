using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Windows
{
    class Frame : GameObject, IREnderable
    {
        private char frameChar;

        public Frame (int x, int y, int width, int heigh, char frameChar) : base (x, y, width, heigh)
        {
            this.frameChar = frameChar;
        }

        public override void Render()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i==0||i==Height-1)
                    {
                        Console.SetCursorPosition(j+X, i+Y);
                        Console.Write(frameChar);
                    }
                    else if (j == 0||j==Width-1)
                    {
                        Console.SetCursorPosition(j+X, i+Y);
                        Console.Write(frameChar);
                    }
                    else
                    {
                        Console.SetCursorPosition(j+X, i+Y);
                        Console.Write(' ');
                    }
                }
            }
        }
    }
}
