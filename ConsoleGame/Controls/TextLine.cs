using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Windows;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Controls
{
    class TextLine : GameObject, IREnderable
    {
        int x, y, width;
        string textLine;

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public TextLine (int x, int y, int width, string textLine) : base (x, y, width, 1)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.textLine = textLine;
        }

        public override void Render()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(textLine);
        }
    }
}
