using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Windows
{
    class Window : GameObject, IREnderable
    {
        Frame windowFrame;

        public Window(int x, int y, int width, int height, char frameChar) : base (x, y, width, height)
        {
            windowFrame = new Frame(x, y, width, height, frameChar);
        }

        public override void Render()
        {
            windowFrame.Render();
        }
    }
}
