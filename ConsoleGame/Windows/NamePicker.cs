using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Controls;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Windows
{
    class NamePicker : Window, IREnderable
    {
        private int x, y, width, height;
        private char frameChar;
        private string inputText = "Please enter your name:";
        private int inputWidth = 30;
        private int inputHeight = 5;
        private string name;
        private Input getName;
        public string Name
        {
            get
            {
                return name;
            }
        }

        public NamePicker(int x, int y, int width, int height, char frameChar) : base(x, y, width, height, frameChar)
        {
            getName = new Input(x + width / 2 - inputWidth / 2, y + height / 2 - inputHeight/2 -1, inputWidth, inputHeight, inputText);
        }

        public override void Render()
        {
            base.Render();
            getName.Render();
            name = getName.GetInput();
        }
    }
}
